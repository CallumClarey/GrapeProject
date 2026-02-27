using Core.GameObjects;

namespace Core.Components;

public abstract class SingletonComponent<T>  : Component where T : Component
{
    public SingletonComponent<T> Instance { private set; get; }

    
    protected SingletonComponent(GameObjectId objectId) : base(objectId)
    {
        //check to see if the instance is null
        if (Instance is not null) return;
        Instance = this;
    }
}