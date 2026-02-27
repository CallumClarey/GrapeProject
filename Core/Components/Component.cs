using Core.GameObjects;


namespace Core.Components;

/// <summary>
/// Base class for all components in the engine.
/// Every component will be owned be a game object 
/// </summary>
public abstract class Component(GameObjectId objectId)
{
    //the object that the component is a handle to
    public readonly GameObjectId ObjectId = objectId;
    //the Component ID 
    
    //All abstract functions 
    //-------------------------------
    /// <summary>
    /// Called before the game starts
    /// </summary>
    public abstract void Start();
    
    /// <summary>
    /// Calls on every frame
    /// </summary>
    public abstract void Update();
    
    /// <summary>
    /// Calls on every physics update
    /// </summary>
    public abstract void FixedUpdate();

    /// <summary>
    /// called after the 
    /// </summary>
    public abstract void LateUpdate();
    
    /// <summary>
    /// Called before the render
    /// </summary>
    public abstract void PreRender();
    
    /// <summary>
    /// Called on the same frame as the render
    /// </summary>
    public abstract void Render();
    
}