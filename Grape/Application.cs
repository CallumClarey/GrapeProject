using System.Runtime.InteropServices;
using GrapeGUI.Backend;
using ImGuiNET;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace GrapeGUI;

/// <summary>
/// This is the partial class don't write general code in here boilerplate code to make the editor work
/// The actual code for the editor should be written inside the Editor class
/// </summary>
/// <param name="gameWindowSettings"></param>
/// <param name="nativeWindowSettings"></param>
internal sealed partial class Editor(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
    : GameWindow(gameWindowSettings, nativeWindowSettings)
{
    
    // This function runs on every update frame.
    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);
        //editor update
        OnUpdate(e);
    }

    protected override void OnLoad()
    {
        base.OnLoad();

        Title += ": OpenGL Version: " + GL.GetString(StringName.Version);

        GL.DebugMessageCallback(DebugProcCallback, IntPtr.Zero);
        GL.Enable(EnableCap.DebugOutput);
        GL.Enable(EnableCap.DebugOutputSynchronous);

        ImGui.CreateContext();
        ImGuiIOPtr io = ImGui.GetIO();
        io.ConfigFlags |= ImGuiConfigFlags.NavEnableKeyboard;
        io.ConfigFlags |= ImGuiConfigFlags.NavEnableGamepad;
        io.ConfigFlags |= ImGuiConfigFlags.DockingEnable;
        io.ConfigFlags |= ImGuiConfigFlags.ViewportsEnable;

        //Function to call in the other half of the partial class 
        InitEditor();

        //ImGui.StyleColorsDark();

        //ImGuiStylePtr style = ImGui.GetStyle();
        //if ((io.ConfigFlags & ImGuiConfigFlags.ViewportsEnable) != 0)
        //{
        //    style.WindowRounding = 0.0f;
        //    style.Colors[(int)ImGuiCol.WindowBg].W = 1.0f;
        //}

        ImguiImplOpenTK4.Init(this);
        ImguiImplOpenGL3.Init();
    }
    
    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);

        ImguiImplOpenGL3.NewFrame();
        ImguiImplOpenTK4.NewFrame();
        ImGui.NewFrame();

        //editor render function
        Render();
        
        ImGui.Render();
        GL.Viewport(0, 0, FramebufferSize.X, FramebufferSize.Y);
        GL.ClearColor(new Color4(0, 32, 48, 255));
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit | ClearBufferMask.StencilBufferBit);
        ImguiImplOpenGL3.RenderDrawData(ImGui.GetDrawData());

        if (ImGui.GetIO().ConfigFlags.HasFlag(ImGuiConfigFlags.ViewportsEnable))
        {
            ImGui.UpdatePlatformWindows();
            ImGui.RenderPlatformWindowsDefault();
            Context.MakeCurrent();
        }

        SwapBuffers();
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);
        GL.Viewport(0,0,Size.X, Size.Y);
    }


    public void OnClosed()
    {
        ImguiImplOpenGL3.Shutdown();
        ImguiImplOpenTK4.Shutdown();
    }


    /// <summary>
    /// Debug functionality try to understand this at a later date
    /// </summary>
    public static readonly DebugProc DebugProcCallback = Window_DebugProc;
    private static void Window_DebugProc(DebugSource source, DebugType type, int id, DebugSeverity severity, int length, IntPtr messagePtr, IntPtr userParam)
    {
        string message = Marshal.PtrToStringAnsi(messagePtr, length);

        bool showMessage = true;

        switch (source)
        {
            case DebugSource.DebugSourceApplication:
                showMessage = false;
                break;
            case DebugSource.DontCare:
            case DebugSource.DebugSourceApi:
            case DebugSource.DebugSourceWindowSystem:
            case DebugSource.DebugSourceShaderCompiler:
            case DebugSource.DebugSourceThirdParty:
            case DebugSource.DebugSourceOther:
            default:
                showMessage = true;
                break;
        }

        if (showMessage)
        {
            switch (severity)
            {
                case DebugSeverity.DontCare:
                    Console.WriteLine($"[DontCare] [{source}] {message}");
                    break;
                case DebugSeverity.DebugSeverityNotification:
                    //Logger?.LogDebug($"[{source}] {message}");
                    break;
                case DebugSeverity.DebugSeverityHigh:
                    Console.Error.WriteLine($"Error: [{source}] {message}");
                    break;
                case DebugSeverity.DebugSeverityMedium:
                    Console.WriteLine($"Warning: [{source}] {message}");
                    break;
                case DebugSeverity.DebugSeverityLow:
                    Console.WriteLine($"Info: [{source}] {message}");
                    break;
                default:
                    Console.WriteLine($"[default] [{source}] {message}");
                    break;
            }
        }
    }




}