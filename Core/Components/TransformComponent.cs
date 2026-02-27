using System.Numerics;
using System.Runtime.InteropServices;
using Core.Engine_Buffers;
using Core.GameObjects;

namespace Core.Components;

/// <summary>
/// Transform data struct 
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public struct Transform(Vector3 position, Quaternion rotation, Vector3 scale) 
    : IComponentBufferType
{

    //Spacial data
    public Vector3 Position = position;
    public Quaternion Rotation = rotation;
    public Vector3 Scale = scale;
    
    //local space
    public Vector3 LocalPosition = Vector3.Zero;
    public Quaternion LocalRotation = Quaternion.Identity;
    public Vector3 LocalScale = Vector3.One;
    
    
    //transform overloads 
    //-----------------------
    public Transform(GameObjectId parent,Vector3 position, Quaternion rotation) 
        : this(position, rotation, Vector3.One) { }

    public Transform(GameObjectId parent,Vector3 position) 
        : this(position, Quaternion.Identity, Vector3.One) { }
    
}