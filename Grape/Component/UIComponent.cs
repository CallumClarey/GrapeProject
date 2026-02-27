using System;
using System.Collections.Generic;
using System.Text;
using IGUIE.Backend;
using IGUIE.Container;

namespace IGUIE.Component;

/// <summary>
/// This class is used to represent items inside of a window e.g. menus and buttons.
/// Note: Owners can only be set once and can not be changed 
/// </summary>
internal abstract class UIComponent
{
    //the owning container 
    private readonly UIContainer owner;
    private string displayName;
    public UISize Size;


    //store the action values of the UI Comp
    //start and stop delegates 
    private Action StartDel;
    private Action StopDel;

    public UIComponent(UIContainer pContainer,string pName, UISize pSize, bool initOnCreation = true)
    {
        owner = pContainer;
        displayName = pName;
        if (!initOnCreation) return;
        InitComponent();
    }

    //abstract function that will be overiden in base classes
    public abstract void InitComponent();

    //returns the owner 
    public UIContainer GetOwner() => owner;

    //allows us to set the start stop delegates
    protected void SetStartStop(Action pStartFunc, Action pStopFunc)
    {
        StartDel = pStartFunc;
        StopDel = pStopFunc;
    }
    
    //invokes the stop
    public void InvokeStop() => StopDel?.Invoke();

}
