using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GrapeCore.Shaders;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace GrapeCore;

public partial class Game(int width, int height, string title) :
    GameWindow(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title })
{

    //used for the graphics engine
    private int _VBO;
    private int _VAO;
    private int _EBO;
    
    //shader attribute
    private Shader _shader;


    //Functions for rendering and update

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);

        if (KeyboardState.IsKeyDown(Keys.Escape))
        {
            Close();

        }
    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);
        GL.Clear(ClearBufferMask.ColorBufferBit);
        
        //None boilerplate functionality below
        _shader.UseShader();
        GL.BindVertexArray(_VAO);
        
        //Type info such as draw data type and method of draw
        //last param points to the start of the array
        GL.DrawElements(PrimitiveType.Triangles,_indices.Length,DrawElementsType.UnsignedInt,0);

        //swaps the buffering system 
        SwapBuffers();
    }


    protected override void OnLoad()
    {
        base.OnLoad();
        //Determines the colour of the background 
        // If a change to the editor level editor is required most likely goes here
        //given in normalised colour values
        GL.ClearColor(0.2f, 0.3f, 0.3f, 1.0f);

        //generates and empty buffer and then gives us the value of the handle
        //Then bind the buffer in openGL anytime the buffer needs modifying the buffer here will be changed
        _VBO = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer,_VBO);
        //Binds the data of the triangle vertex array to the buffer determining size and draw type
        GL.BufferData( BufferTarget.ArrayBuffer,_squareVert.Length * sizeof(float), _squareVert , BufferUsageHint.StaticDraw);

        //Same as before generates an empty vertex array then binds it to openGL context
        _VAO = GL.GenVertexArray();
        GL.BindVertexArray(_VAO);
        //determines the size of the stride and then allocated the appropriate memory
        GL.VertexAttribPointer(0,3, VertexAttribPointerType.Float, false, 3 * sizeof(float),0);
        GL.EnableVertexAttribArray(0);


        //EBO is linked directly to the VAO meaning resource do not need disposing 
        //as when the VAO is disposed the EBO is disposed along with it 
        //Defining an EBO before a VAO is undefined behaviour
        _EBO = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ElementArrayBuffer, _EBO);
        GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length *sizeof(uint), _indices, BufferUsageHint.StaticDraw);


        //Create a shader
        //then use the shader 
        _shader = new Shader();
        _shader.UseShader();

    }


    protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
    {
        base.OnFramebufferResize(e);
        GL.Viewport(0,0, e.Width, e.Height);
    }
}