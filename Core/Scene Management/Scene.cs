using Core.Components;
using Core.GameObjects;

namespace Core;

/// <summary>
/// Used to represent levels within the game each scene will require a game mode.
/// </summary>
public sealed class Scene
{
    
    //TODO: add complexity to this system
    public static GameModeBase CurrentGameMode { get; private set;}
    public void ChangeGameMode(GameModeBase newGameMode) => CurrentGameMode = newGameMode;
    
    
    //list of all game objects in the scene 
    private List<GameObject> gameObjects = [];
    

    
}