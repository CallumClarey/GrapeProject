using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ImGuiNET;

namespace IGUIE.OLD.Menu;

internal sealed class Menu(string name)
{
    public List<MenuItem> MenuItems = [];
    internal string MenuName = name;

    //Creates a menu
    public void CreateMenu()
    {
        //Begins the main menu
        if (ImGui.BeginMenu(MenuName))
        {
            var items = CollectionsMarshal.AsSpan(MenuItems);
            foreach (var item in items)
            {
                item.MenuItemFunc();
            }
        }
        ImGui.EndMenu();
    }

}