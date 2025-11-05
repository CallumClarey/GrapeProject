using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using Editor = GrapeGUI.Editor;

var nativeWindowSettings = new NativeWindowSettings()
{
    ClientSize = new Vector2i(800, 600),
    Title = "Splash",
    Flags = ContextFlags.ForwardCompatible,
};

// To create a new window, create a class that extends GameWindow, then call Run() on it.
using var app = new Editor(GameWindowSettings.Default, nativeWindowSettings);
app.Run();
