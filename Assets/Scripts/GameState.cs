using System;

public static class GameState
{
    public static Action OnGameRestarted;
    public static Action OnGameFinished;

    public static void RestartGame()
    {
        OnGameRestarted.Invoke();
    }

    public static void EndGame()
    {
        OnGameFinished.Invoke();
    }
}
