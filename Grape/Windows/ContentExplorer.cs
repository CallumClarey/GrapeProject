using ImGuiNET;

namespace GrapeGUI.Windows;

/// <summary>
/// The Content explorer 
/// </summary>
internal class ContentExplorer : Window
{
    /// <summary>
    /// The Content explorer 
    /// </summary>
    /// <param name="name"></param>
    public ContentExplorer(string name) : base(name)
    {
        WindowFunctions += DisplayText;
    }
    //Constructor that determines the action added to the window

    public void DisplayText()
    {
        ImGui.Text("Hello World");
    }

}