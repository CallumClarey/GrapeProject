using System.Numerics;
using IGUIE.OLD.Menu;
using IGUIE.OLD.Windows;
using IGUIE.OLD.Styling;
using ImGuiNET;
using OpenTK.Windowing.Common;
using SystemVector2 = System.Numerics.Vector2;


namespace IGUIE;

//the other half of the class 
internal sealed partial class Editor
{
    //the manager object in charge of controlling the windows
    private WindowManager? _windowManager;
    private ImGuiStylePtr _style;

    //runs when the editor loads
    private void InitEditor()
    {

        _windowManager = new WindowManager();
        _windowManager.AddWindow(new ContentExplorer("Content Explorer"));
    }

    
    private void OnUpdate(FrameEventArgs e)
    {
        //serialisation calls are going to have to be placed here
    }

    private void Render()
    {
        //sets the editor style for all windows inside the editor
        SetEditorStyle();
        CreateDockspace();
        MainMenu.CreateMainMenu();
        _windowManager?.RenderWindows();
    }

    private void EditorUnload()
    {

    }



    /// <summary>
    /// Code used to create a main dockspace for the main window
    /// </summary>

    private const string DOCKSPACE = "EditorDockspace";

    private const ImGuiWindowFlags WINDOW_FLAGS = ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoCollapse |
                                                  ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove |
                                                  ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus
                                                  | ImGuiWindowFlags.NoDocking | ImGuiWindowFlags.MenuBar | ImGuiWindowFlags.NoScrollbar;

    private static void CreateDockspace()
    {
        var imGuiViewport = ImGui.GetMainViewport();
        ImGui.SetNextWindowPos(imGuiViewport.Pos);
        ImGui.SetNextWindowSize(imGuiViewport.Size);
        ImGui.SetNextWindowViewport(imGuiViewport.ID);

        //Add just styling here 
        var style = ImGui.GetStyle();
        style.WindowRounding = 0.0f;

        ImGui.Begin(DOCKSPACE, WINDOW_FLAGS);
        ImGui.DockSpace(ImGui.GetID(DOCKSPACE), SystemVector2.Zero, ImGuiDockNodeFlags.PassthruCentralNode);

        //centres the text in the middle of the screen
        Window.CentreText("Empty Dockspace", ()
            => ImGui.Text("Empty Dockspace"));

        ImGui.End();
    }



    public void SetEditorStyle()
    {
        _style = ImGui.GetStyle();
        _style.Colors[(int)ImGuiCol.WindowBg] = new GuiColor(0x31363F, 255f).Color; 
        _style.Colors[(int)ImGuiCol.DockingPreview] = new GuiColor(218f, 238, 254f, 255f).Color;
        _style.Colors[(int)ImGuiCol.TitleBg] = new GuiColor(0xFF6500, 230).Color;
        _style.Colors[(int)ImGuiCol.TitleBgActive] = new GuiColor(0xFF6500 ,230).Color;
        _style.Colors[(int)ImGuiCol.TabHovered] = new GuiColor(218f, 238, 254f, 255f).Color;
        _style.Colors[(int)ImGuiCol.MenuBarBg] = new GuiColor(0x222831, 255f).Color;


        _style.WindowPadding = Vector2.One;
        _style.WindowBorderSize = 2.0f;
        _style.ChildBorderSize = 0.0F;

        //ImGui.Begin("Window");
        //ImGui.ColorPicker4("Picker", ref colour);

        //ImGui.End();
    }

}