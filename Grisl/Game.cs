using GRISL;
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
        Console.WriteLine(IsAnyKeyDown.ToString());
     

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