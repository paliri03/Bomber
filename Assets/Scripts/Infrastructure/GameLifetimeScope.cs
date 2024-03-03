using UnityEngine;
using VContainer;
using VContainer.Unity;

public class GameLifetimeScope : LifetimeScope
{
    [Header("Services")]
    [SerializeField] private Mobile_InputService mobileInputService;
    [SerializeField] private NavMeshPathfinding navMeshPathfinding;

    [Header("Clients")]
    [SerializeField] private EnemiesController enemiesController;

    [Header("Prefabs")]
    [SerializeField] private CameraController cameraController;
    [SerializeField] private Player player;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<GamePresenter>();
        builder.RegisterEntryPoint<PlayerPresenter>();


        if (SystemInfo.deviceType == DeviceType.Handheld || SystemInfo.deviceType == DeviceType.Desktop)
            builder.RegisterInstance<IInputService>(mobileInputService);
        builder.RegisterInstance<IPathfinding>(navMeshPathfinding);


        builder.RegisterComponent(enemiesController);


        builder.RegisterComponentInNewPrefab(cameraController, Lifetime.Scoped);
        builder.RegisterComponentInNewPrefab(player, Lifetime.Scoped);
    }
}
