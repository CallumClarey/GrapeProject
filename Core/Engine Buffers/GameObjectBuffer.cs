using Core.GameObjects;

namespace Core.Engine_Buffers;

/// <summary>
/// The buffer of all the game objects in a scene 
/// </summary>
internal sealed class GameObjectBuffer : EngineBuffer<GameObject>
{
    /// <summary>
    /// Override for the game object buffer 
    /// </summary>
    /// <param name="item"></param>
    public new void Insert(GameObject item)
    {
        //resize the buffer
        if(CheckBufferSize) ResizeBuffer();
        //increment the count
        Count++;
        
        //updates the object handle 
        item.UpdateObjectHandle(Count, GenerationBuffer[Count]);
        Buffer[Count] = item;
    }
    
    /// <summary>
    /// Override for the game object buffer to remove 
    /// </summary>
    /// <param name="index"></param>
    public override void Remove(int index)
    {
        base.Remove(index);
        Buffer[index].UpdateObjectHandle(index,GenerationBuffer[index]);
    }
}