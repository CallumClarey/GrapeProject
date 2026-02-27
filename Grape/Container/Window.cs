using System;
using System.Collections.Generic;
using System.Text;
using IGUIE.Backend;
using ImGuiNET;

namespace IGUIE.Container;

internal class Window : UIContainer, IContainerUtils
{
    public Window(string pName,UISize pSize, in Action functionToRun) : base(pName,pSize)
    {
        CreateContainer(functionToRun);
    }

    public override void CreateContainer(Action WindowAction)
    {
        ImGui.Begin(Name);
        RunContainer();
        ImGui.End();
    }

    public void RunContainer() {
        Console.WriteLine("No Implmentation of container running");   
    }
}
