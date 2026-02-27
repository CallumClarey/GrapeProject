
using Core.GameObjects;

namespace Core.Engine_Buffers;

//buffer type tag and data handle tag
internal interface IBufferType;

internal interface IComponentBufferType : IBufferType;

/// <summary>
/// Internal buffer used for engine
/// Zero index is reserved for null value
/// Generations start at zero
/// </summary>
/// <typeparam name="T"></typeparam>
internal class EngineBuffer<T>() where T : IBufferType 
{
    //The default buffer constants
    private const int DEFAULT_BUFFER_SIZE = 1024;
    private const int DEFAULT_PADDING = 10;
    
    //buffer size and the 
    private int bufferSize = DEFAULT_BUFFER_SIZE;
    protected T[] Buffer = new T[DEFAULT_BUFFER_SIZE];
    protected uint[] GenerationBuffer = new uint[DEFAULT_BUFFER_SIZE];
    protected int Count = 1;
    
    
    /// <summary>
    /// Constructor that allows for creating none default sizes 
    /// </summary>
    /// <param name="pBufferSize"></param>
    internal EngineBuffer(int pBufferSize) : this()
    {
        bufferSize = pBufferSize;
        GenerationBuffer = new uint[pBufferSize];
        Buffer = new T[pBufferSize];
    } 
    
    
    /// <summary>
    /// The buffer doubles in length each time
    /// Code works fine for now can be optimised later 
    /// </summary>
    protected void ResizeBuffer()
    {
        bufferSize *= 2;
        var newBuffer = new T[bufferSize];
        var newGenerationBuffer = new uint[bufferSize];
        Array.Copy(Buffer, newBuffer, Buffer.Length);
        Array.Copy(GenerationBuffer, newGenerationBuffer, GenerationBuffer.Length);
        GenerationBuffer = newGenerationBuffer;
        Buffer = newBuffer;
    }
    
    
    //check if the buffer needs resizing 
    protected bool CheckBufferSize => Count >= bufferSize - DEFAULT_PADDING;


    /// <summary>
    /// Adds an item to the buffer
    /// </summary>
    /// <param name="item"></param>
    public virtual void Insert(T item, int index) 
    {
        //resize the buffer
        if(CheckBufferSize) ResizeBuffer();
        //increment the count
        Count++;
        Buffer[Count] = item;
    }
    
    
    /// <summary>
    /// Removes an item at a given index
    /// Returns the handle to create a new 
    /// </summary>
    /// <param name="index"></param>
    public virtual void Remove(int index)
    {
        //check for overflow
        if(index > Count) return;    
        
        //sets the empty spot to null
        Buffer[index] = default!;
        //increment the generation buffer
        GenerationBuffer[index]++;
        
        //sets the last item to fill the slot
        Buffer[index] = Buffer[Count];
        Count--;
    }

    
    /// <summary>
    /// gets the value at the index 
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public T? Get(int index) => index > Count ? default : Buffer[index];
}