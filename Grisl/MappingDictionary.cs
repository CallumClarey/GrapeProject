using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace GRIS;

/// <summary>
/// Class used to represent a collection of mappings 
/// </summary>
public sealed class MappingDictionary
{
    //strong the dirctionary of the mapping contexts 
    //can be used to store types such as walking, swimming, flying 
    private Dictionary<string,string> MappingTable = new();
    
    //adds a mapping to the dictionary
    public void AddMapping(string mappingName)
    {

    }

    /// <summary>
    /// Used to removing mapping by the tag (name)
    /// </summary>
    /// <param name="mappingName"></param>
    public void RemoveMapping(string mappingName) 
    { 
    
    }
}
