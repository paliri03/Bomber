using VContainer.Unity;

public class GamePresenter : IStartable
{
    readonly IPathfinding pathfinding;
    readonly EnemiesController enemiesController;

    public GamePresenter(IPathfinding pathfinding, EnemiesController enemiesController)
    {
        this.pathfinding = pathfinding;
        this.enemiesController = enemiesController;
    }

    public void Start()
    {
       pathfinding.Init();

       enemiesController.SpawnEnemies();
       GameState.OnGameRestarted += enemiesController.SpawnEnemies;
    }
}