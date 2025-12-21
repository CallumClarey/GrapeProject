using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace GRIS;

public class Game(int width, int height, string title) :
    GameWindow(GameWindowSettings.Default, new NativeWindowSettings() { Size = (width, height), Title = title })
{


    //Functions for rendering and update

    protected override void OnUpdateFrame(FrameEventArgs args)
    {
        base.OnUpdateFrame(args);

        Float input = 1.0f;

        var move = new InputEvent<Float>();
        

        if (KeyboardState.IsKeyDown(Keys.Escape))
        {
            Close();
        }

        if (KeyboardState.IsKeyDown(Input.Read(Keyboard.A)))
        {
            Console.WriteLine("A pressed");
        }
     

    }

    protected override void OnRenderFrame(FrameEventArgs args)
    {
        base.OnRenderFrame(args);
        GL.Clear(ClearBufferMask.ColorBufferBit);
        SwapBuffers();
    }


    protected override void OnLoad()
    {
        base.OnLoad();
    }


    protected override void OnFramebufferResize(FramebufferResizeEventArgs e)
    {
        base.OnFramebufferResize(e);
        GL.Viewport(0,0, e.Width, e.Height);
    }
}