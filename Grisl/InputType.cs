using OpenTK.Mathematics;

namespace GRISL;

//type tag used to restrict the type the event can have
public interface IInputType;

//boolean input type
public struct Boolean: IInputType
{
    bool Value;
    //converts the struct down to the backing field 
    public static implicit operator bool(Boolean i) => i.Value;
    //When creating a new input bool can set the value from just an equals no new keyword required
    public static implicit operator Boolean(bool v) => new() { Value = v };
}

public struct Integer : IInputType
{
    int Value;
    //converts the struct down to the backing field 
    public static implicit operator int(Integer i) => i.Value;
    //When creating a new input int can set the value from just an equals no new keyword required
    public static implicit operator Integer(int v) => new() { Value = v };

}

public struct Float : IInputType
{
    //backing value
    public float Value;
    //converts the struct down to the backing field 
    public static implicit operator float(Float i) => i.Value;
    //When creating a new input float can set the value from just an equals no new keyword required
    public static implicit operator Float(float v) => new() { Value = v };
}


public struct InputVec2 : IInputType
{
    Vector2 value;
}


public struct InputVec3: IInputType
{
    Vector3 value;
}