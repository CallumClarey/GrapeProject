using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GRISL.InputSystem;


public sealed class MappingContext
{
    //stores and array of input contexts 
    private Dictionary<string, InputContext> contextMap = new();
    //Context array
    private List<InputContext> contextArray = new();
    //the context that will be quered by the input manager 
    private InputContext? activeContext = null;

    /// <summary>
    /// Gets the context of the input system via the dictionary key
    /// </summary>
    /// <param name="tagName"></param>
    /// <returns></returns>
    public InputContext? GetContextByTag(string tagName)
    {
        if(contextMap.TryGetValue(tagName, out var context)) return context;
        return null;
    } 

    /// <summary>
    /// Gets the context via the index in the array
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public InputContext? GetContextByIndex(int value)
    {
        //check for a out of range value
        if (value <= contextArray.Count) return contextArray[value];
        return null;
    }
}
