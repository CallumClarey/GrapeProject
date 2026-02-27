using System;
using System.Collections.Generic;
using System.Text;
using IGUIE.Backend;
using ImGuiNET;

namespace IGUIE.Container;

internal class MainDockspace : UIContainer, IContainerUtils
{
    //the name of the dockspace
    private const string DOCKSPACE = "Editor Dockspace";
    //dockspace defaults 
    private const ImGuiWindowFlags WINDOW_FLAGS = ImGuiWindowFlags.NoTitleBar | ImGuiWindowFlags.NoCollapse |
                                                 ImGuiWindowFlags.NoResize | ImGuiWindowFlags.NoMove |
                                                 ImGuiWindowFlags.NoBringToFrontOnFocus | ImGuiWindowFlags.NoNavFocus
                                                 | ImGuiWindowFlags.NoDocking | ImGuiWindowFlags.MenuBar | ImGuiWindowFlags.NoScrollbar;



    public MainDockspace() : base(DOCKSPACE, new UISize(10,10))
    {

    }

    public override void CreateContainer(Action containerFunc)
    {
        throw new NotImplementedException();
    }

    void IContainerUtils.RunContainer()
    {
        throw new NotImplementedException();
    }
}
