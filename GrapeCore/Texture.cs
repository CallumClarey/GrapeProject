using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common.Input;
using StbImageSharp;

namespace GrapeRenderer;

public class Texture(int glHandle)
{
    //Texture handler pointer 
    public readonly int Handle = glHandle;

    //TODO: Introduce different types of Texture filtering


    public static Texture LoadTextureFromFile(string path)
    {
        //Creates a blank new texture handle
        var handle = GL.GenTexture();

        //Sets the active texture slot 
        //then binds the texture to the local handle 
        GL.ActiveTexture(TextureUnit.Texture0);
        GL.BindTexture(TextureTarget.Texture2D, handle);
        //textures are loaded upside down in Stb image as the file is read backwards
        StbImage.stbi_set_flip_vertically_on_load(0);

        using var textureStream = File.OpenRead(path);
        var image = ImageResult.FromStream(textureStream, ColorComponents.RedGreenBlueAlpha);
        //creates the openGL texture
        GL.TexImage2D(TextureTarget.Texture2D,0, PixelInternalFormat.CompressedRgba, 
            image.Width,image.Height,0,
            PixelFormat.Rgba,PixelType.UnsignedByte,image.Data);

        
        //Reconfigurable texture parameters
        TextureFilter();
        TextureWrapping();

        //generates the smaller versions of the texture 
        GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);

        return new Texture(handle);
    }


    /// <summary>
    /// Takes a texture uint from OPENGL as a param.
    /// 
    /// sets the active texture to the uint.
    /// Binds the texture to handle in the Obj.
    /// </summary>
    /// <param name="uintP"></param>
    public void Use(TextureUnit uintP)
    {
        GL.ActiveTexture(uintP);
        GL.BindTexture(TextureTarget.Texture2D, Handle);
    }


    //code used to determine texture filtering 
    private static void TextureFilter()
    {
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
    }

    //Code used for texture wrapping 
    private static void TextureWrapping()
    {
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
        GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
    }
}