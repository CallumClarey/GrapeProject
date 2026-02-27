using System.Runtime.InteropServices;

namespace IGUIE.OLD.Windows;

/// <summary>
/// Class used to manage all the windows the editor needs to use.
/// Note: Functionality of this class may need to change when scene viewports are introduced
/// </summary>
internal sealed class WindowManager
{
    //Window collections the manage the window 
    public List<Window> WindowList { get; } = [];
    public Dictionary<string, Window> WindowDict { get; } = new();


    //TODO: ADD more functionality to catch multiple windows of the same type
    /// <summary>
    /// Adds a window object into the collection inside the window manager.
    /// The two collections include a list and a hash table/ Dictionary
    /// </summary>
    /// <param name="editorWindow"></param>
    public void AddWindow(Window editorWindow)
    {
        WindowList.Add(editorWindow);
        WindowDict.Add(editorWindow.Name, editorWindow);
    }
    
    /// <summary>
    /// Renders the windows in the collection to the screen.
    /// </summary>
    public void RenderWindows()
    {
        //Converts windows to span 
        //loops through each window obj and then calls the init function contained in the window classes
        var collection = CollectionsMarshal.AsSpan(WindowList);
        foreach (var window in collection) { window.InitWindow(); }
    }


}