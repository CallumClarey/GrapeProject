using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrapeGUI.Menu;


/// <summary>
/// Class used to contain items in a menu list.
/// Constructor takes params of the label and the function the menu option provides
/// </summary>
/// <param name="label"></param>
/// <param name="function"></param>
internal sealed class MenuItem(string label, Action function)
{
    private readonly Action? _menuFunc = function;
    private string _itemLabel = label; 

    /// <summary>
    /// Function used to create a menuItem
    /// </summary>
    public void MenuItemFunc() => _menuFunc?.Invoke();
}