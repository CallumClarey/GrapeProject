namespace Core.GameObjects;

/// <summary>
/// Structure used to represent game object handles
/// </summary>
/// <param name="id"></param>
public readonly struct GameObjectId(uint id)
{
    //the handle reserved for all 
    public const uint NULL_HANDLE = 0;
    
    public static readonly GameObjectId NULL_OBJECT_ID = new (NULL_HANDLE);
    
    //unsigned int value for object ids 
    public readonly uint Value = id;

    //extract the 24 bytes for the index
    public int Index => (int)(Value & 0xFFFF); 
    //use the bottom 8 bytes for a generation (how many object have used this index slot)
    public int Generation => (int)(Value >> 24);
    
    /// <summary>
    /// Function used to create an object handle 
    /// </summary>
    /// <param name="index"></param>
    /// <param name="generation"></param>
    /// <returns></returns>
    public static GameObjectId CreateHandle(int index, uint generation) 
        => new((uint)index | generation << 24);
    
}