using System.Numerics;
using Core.Components;
using Core.Engine_Buffers;
using Core.GameObjects;

namespace Core.Registers;

/// <summary>
/// Class used to store all game object 
/// </summary>
public static class GameObjectManager
{
    //Game object pool storing all objects in scene 
    
    private static readonly GameObjectBuffer GameObjectPool = new();
    private static readonly EngineBuffer<Transform> TransformPool = new();


    /// <summary>
    /// Adds an object to the pool and then links a transform to it 
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="position"></param>
    /// <param name="rotation"></param>
    /// <param name="scale"></param>
    internal static void AddGameObjectToPool(GameObject gameObject, Vector3 position, Quaternion rotation, 
        Vector3 scale) 
    {
        //will create a new game object instance 
        //TODO: REWORK WHEN PREFAB SUPPORT IS ADDED 
        if (Activator.CreateInstance(gameObject.GetType()) is not GameObject newGameObject) return;
        
        //adds the game object to the pool
        //id is created by the buffer so it can now be accessed here 
        GameObjectPool.Insert(newGameObject);
        
        //give the game object a transform
        var transform = new Transform(position, rotation, scale);
        TransformPool.Insert(transform, newGameObject.ObjectObjectId.Index);
    }
    
    
    //Overloads for the function
    //------------------------------------------------
    internal static void AddGameObjectToPool(GameObject gameObject, Vector3 position, Quaternion rotation)
    => AddGameObjectToPool(gameObject, position, rotation, Vector3.One);
    
    internal static void AddGameObjectToPool(GameObject gameObject, Vector3 position)
        => AddGameObjectToPool(gameObject,position,Quaternion.Identity,Vector3.One);

    internal static void AddGameObjectToPool(GameObject gameObject) 
        => AddGameObjectToPool(gameObject, Vector3.Zero, Quaternion.Identity, Vector3.One);


    /// <summary>
    /// Removes an object from game object pool and the transform pool
    /// </summary>
    /// <param name="gameObjectId"></param>
    internal static void RemoveGameObjectFromPool(GameObjectId gameObjectId)
    {
        GameObjectPool.Remove(gameObjectId.Index);
        TransformPool.Remove(gameObjectId.Index);
    }
}