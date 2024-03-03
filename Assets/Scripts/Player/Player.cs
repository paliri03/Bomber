using UnityEngine;
using VContainer;

public class Player : MonoBehaviour
{
    [SerializeField] private PlayerModel playerModel;
    [SerializeField] private InventorySystem inventorySystem;
    [SerializeField] private PlayerView playerView;


    [Inject] public void Init(IInputService inputService)
    {
        inputService.OnTap += TapEvent;       
        inventorySystem.InitInventory(playerModel.AvailableItems);

        playerView.Init();
        playerView.OnRestartButtonClicked += GameState.RestartGame;

        GameState.OnGameRestarted += playerView.OpenInventory;
        GameState.OnGameFinished += playerView.OpenGameOverWindow;
    }

    private void TapEvent(Vector2 tapPoint)
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(tapPoint), out RaycastHit hit))
        {
            var worldCoordinates = hit.point;

            var spawnPosition = new Vector3(worldCoordinates.x, playerModel.ItemSpawnHeight, worldCoordinates.z);
            inventorySystem.DropItem(spawnPosition);
        }
    }
}
