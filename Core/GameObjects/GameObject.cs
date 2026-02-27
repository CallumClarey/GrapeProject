using System.Numerics;
using System.Runtime.InteropServices;
using Core.Components;
using Core.Engine_Buffers;
using Core.Registers;

namespace Core.GameObjects;


/// <summary>
/// Base class for all game objects in the game 
/// </summary>
public abstract class GameObject : IBufferType
{
    //id for the game object
    public GameObjectId ObjectObjectId { get; private set; }
    
    public bool IsActive { get; private set; } = true;
    
    private readonly List<Component> componentList = [];
    
    
    //The game object id system
    //---------------------------------------------------------------------------
    
    /// <summary>
    /// Updates the game object ID and generate object handle
    /// </summary>
    /// <param name="index"></param>
    /// <param name="generation"></param>
    /// <exception cref="NotImplementedException"></exception>
    public void UpdateObjectHandle(int index, uint generation)
        => ObjectObjectId = GameObjectId.CreateHandle(index, generation);
    
    
    
    //Regular game Component system
    //-------------------------------------------
    private Span<Component> GetComponentsAsSpan() => CollectionsMarshal.AsSpan(componentList);

    /// <summary>
    /// Gets a component of a given type.
    /// Returns null if can not find one in the object
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public T? GetComponent<T>() where T : Component
    {
        var components = GetComponentsAsSpan();
        foreach (var component in components)
        {
            if (component is T t) return t;
        }
        return null;
    }

    
    /// <summary>
    /// Gets all components of type.
    /// Returns a list of all the components of a given type.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public List<T>? GetComponents<T>() where T : Component
    {
        var components = GetComponentsAsSpan();
        var list = new List<T>();
        
        foreach (var component in components) { if(component is T t) list.Add(t); }

        return list.Count >= 0 ? null : list;
    }

    
    /// <summary>
    /// Adds a component of a type to an object.
    /// Returns the created component.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public T CreateComponentOfType<T>() where T : Component
    {
        //creates a new instance of the object
        var newComponent = Activator.CreateInstance<T>();
        componentList.Add(newComponent);
        return newComponent;
    }
    
    
}