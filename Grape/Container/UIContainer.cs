using System;
using System.Collections.Generic;
using System.Text;
using IGUIE.Backend;
using IGUIE.Component;

namespace IGUIE.Container;

internal abstract class UIContainer
{
    //stores the Ui Size Container
    public UISize Size;
    public string Name;
    protected UIContainer(string pName, UISize pSize)
    {
        Name = pName;
        Size = pSize;
    }
    
    //this is going to store all the memeber component end functions 
    private Stack<UIComponent> componentStack = new();

    //loops through and adds all the components on to the container stack
    protected void AddComponentsToStack(UIComponent comp) => componentStack.Push(comp);

    //Pops the top of the stack and call the function to end
    public void EndCurrent() => componentStack.Pop().InvokeStop();
    public void EndAll() { for(var i = componentStack.Count; i >= 0 ; i--) componentStack.Pop();}


    //will be overriden in the window class
    public abstract void CreateContainer(Action containerFunc);
}
