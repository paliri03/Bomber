using VContainer.Unity;

public class PlayerPresenter : IStartable
{
    readonly Player player;
    readonly CameraController camera;

    public PlayerPresenter(Player player, CameraController camera)
    {
        this.player = player;
        this.camera = camera;
    }

    public void Start()
    {
        //
    }
}
