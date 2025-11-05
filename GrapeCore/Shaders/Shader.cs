using OpenTK.Graphics.OpenGL4;

namespace GrapeCore.Shaders;


/// <summary>
/// Class used to represent a shader
/// </summary>
internal sealed class Shader
{
    //The handle for the shader
    private readonly int _handle;

    //Constant Strings used to represent the shader 
    private static readonly string ShaderDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Shaders");
    private const string DEFAULT_VERT_PATH = "shader.vert";
    private const string DEFAULT_FRAG_PATH = "shader.frag";


    public Shader(string? vertPath = null , string? fragPath = null)
    {
        //takes either the frag and vert path from the constructor 
        //or it uses the default paths and combines them the app context
        var vertexPath = vertPath ?? Path.Combine(ShaderDirectory, DEFAULT_VERT_PATH);
        var fragmentPath = fragPath ?? Path.Combine(ShaderDirectory, DEFAULT_FRAG_PATH);

        //read the files at the file path 
        CreateShaderSource(vertexPath,ShaderType.VertexShader, out var vertexShader);
        CreateShaderSource(fragmentPath, ShaderType.FragmentShader, out var fragmentShader);

        //creates a handle and then attaches the shaders ready to be pushed to the GPU
        _handle = GL.CreateProgram();
        GL.AttachShader(_handle, vertexShader);
        GL.AttachShader(_handle, fragmentShader);
        //links the shaders to the program 
        LinkProgram(_handle);

        //Disposes of any unused resources 
        DetachResources(vertexShader);
        DetachResources(fragmentShader);
    }

    
    /// <summary>
    /// This function will be used to compile both the vertex and fragment shader.
    /// Takes a parameter of the shader pointer given as an int
    /// Will handle any errors of the shader compilation 
    /// </summary>
    /// <param name="shader"></param>
    private static void CompileShader(int shader)
    {
        GL.CompileShader(shader);

        //will get the shader and then take the out parameter to see if it returns ant error codes
        GL.GetShader(shader, ShaderParameter.CompileStatus, out var code);
        if (code == (int)All.True) return;
        
        //this code will only run if there has been an error
        var infoLog = GL.GetShaderInfoLog(shader);
        //creates error and then displays the info log 
        throw new Exception($"Error occured whilst compiling ({shader}) : {infoLog}");
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="program"></param>
    /// <exception cref="Exception"></exception>
    private static void LinkProgram(int program)
    {
        GL.LinkProgram(program);
        GL.GetProgram(program, GetProgramParameterName.LinkStatus, out var code);
        //check for an error code 
        if(code == (int)All.True) return;

        var infoLog = GL.GetProgramInfoLog(program);
        //throw a new error 
        throw new Exception($"Error occured whilst Linking Program ({program} : {infoLog})");
    }



    /// <summary>
    /// Function used to read the source of the shaders.
    /// 1. Reads the files
    /// 2. Then creates the shader using the type passed in via the type parameter
    /// 3. Then passes the system to the compile function
    /// </summary>
    /// <param name="filepath"></param>
    /// <param name="type"></param>
    /// <param name="shader"></param>
    private static void CreateShaderSource(string filepath, ShaderType type, out int shader)
    {
        //read the file from source
        var shaderSource = "";
        try { shaderSource = File.ReadAllText(filepath); }
        catch (FileNotFoundException)
        {
            Console.WriteLine("file Not found");
        }

        shader = GL.CreateShader(type);
        GL.ShaderSource(shader,shaderSource);
        CompileShader(shader);
    }


    /// <summary>
    /// Detaches the shader and the deletes it.
    /// </summary>
    /// <param name="shader"></param>
    private void DetachResources(int shader)
    {
        GL.DetachShader(_handle,shader);
        GL.DeleteShader(shader);
    }


    //Function called to use the shader 
    public void UseShader() => GL.UseProgram(_handle);

}