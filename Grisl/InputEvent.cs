
using GRISL;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace GRIS;


/// <summary>
/// Class used to represent input events
/// Stores the value type of the 
/// </summary>
/// <typeparam name="T"></typeparam>
/// <param name="eventVal"></param>
public class InputEvent<T> where T : IInputType
{
    //value of the event
    public T EventValue;

    



}
