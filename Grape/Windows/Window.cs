using System.Numerics;
using System.Runtime.InteropServices.JavaScript;
using ImGuiNET;

namespace GrapeGUI.Windows;

/// <summary>
/// Class which all windows will inherit from,
/// also contains utility functions such as centreText.
/// </summary>
/// <param name="name"></param>
internal class Window(string name) 
{
    //Public class attributes 
    public string Name { get; } = name;
    public bool IsDocked;
    public Action? WindowFunctions;



    /// <summary>
    /// Creates the window with the Imgui Begin and end
    /// In between the beginning and end calls is an Action invoke.
    /// Does this cause performance problems?????
    /// </summary>
    public virtual void InitWindow()
    {
        ImGui.Begin(Name);
        WindowFunctions?.Invoke();
        ImGui.End();
    }

    //Used to set the style later on with a style manager
    public virtual void SetWindowStyle()
    {
        
    }


    //This section contains static util functions to help with window formatting 
    //-----------------------------------------------------------------------------------------

    /// <summary>
    /// Static function used to centre text
    /// Accepts lambda as an argument to display what to centre
    /// </summary>
    /// <param name="text"></param>
    /// <param name="itemToCentre"></param>
    public static void CentreText(string? text, Action? itemToCentre)
    {
        var windowWidth = ImGui.GetWindowSize().X;
        var windowHeight = ImGui.GetWindowSize().Y;
        var textWidth = ImGui.CalcTextSize(text).X;
        var textHeight = ImGui.GetFontSize(); 

        ImGui.SetCursorPosX((windowWidth - textWidth) * 0.5f);
        ImGui.SetCursorPosY((windowHeight - textHeight) * 0.5f);

        // Move cursor to horizontally center
        ImGui.SetCursorPosX((windowWidth - textWidth) * 0.5f);
        itemToCentre?.Invoke();
    }

}