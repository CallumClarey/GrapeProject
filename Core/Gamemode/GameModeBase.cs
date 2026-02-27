namespace Core;


/// <summary>
/// Class in which all game modes will inherit from
/// Every scene in a game will require a game mode
/// Every Game Mode will be a singleton
/// </summary>
public class GameModeBase
{
    /// <summary>
    /// All available states a game mode can be in
    /// </summary>
    public enum GameState
    {
        UNKNOWN,
        STARTED,
        PLAYING,
        PAUSED,
        FINISHED,
    }

    //stores the current state the game is in by default always unknown
    public GameState CurrentGameState { private set; get; } = GameState.UNKNOWN;
    
    /// <summary>
    /// Changed the game state of the current game mode 
    /// </summary>
    /// <param name="newState"></param>
    public void ChangeState(GameState newState) => CurrentGameState = newState;

    //This is needed so gameplay related actions can be seperated from UI actions
    public float GameDeltaTime = 0.0f;
    
    
    
    
    
    
    
}