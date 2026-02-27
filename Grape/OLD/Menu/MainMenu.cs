using System.Runtime.InteropServices;
using ImGuiNET;

namespace IGUIE.OLD.Menu;

internal static class MainMenu
{
    public static List<Menu> Menus = [];
    
    /// <summary>
    /// Function renders the main menu 
    /// </summary>
    public static void CreateMainMenu()
    {
        ImGui.BeginMainMenuBar();

        var menuSpan = CollectionsMarshal.AsSpan(Menus);
        //loops through anc creates each menu on the main menu bar
        //Inside each menu contains menu items 
        foreach (var menu in menuSpan){ menu.CreateMenu();}
        
        ImGui.EndMainMenuBar();
    }



    public static void CreateDefaults()
    {
        //creates the object for the 
        var fileMenu = new Menu("File");
        var windowMenu = new Menu("Window");

        Menus.Add(fileMenu);
        Menus.Add(windowMenu);
    }

}