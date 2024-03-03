using UnityEngine;
using VContainer;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float maxRadius;
    [SerializeField] private float distance;

    private Vector2 defaultPosition;
    private IInputService _inputService;

    [Inject] public void Init(IInputService inputService)
    {
        _inputService = inputService;

        transform.position = startPosition;
        defaultPosition = new Vector2(startPosition.x, startPosition.z);
        _inputService.OnHold += MoveCamera;
    }

    public void MoveCamera(Vector2 delta)
    {
        var currentPosition = new Vector2(transform.position.x, transform.position.z);

        currentPosition = defaultPosition + Vector2.ClampMagnitude(currentPosition - defaultPosition - delta * movementSpeed, maxRadius);

        transform.position = new Vector3(currentPosition.x, distance, currentPosition.y);
    }
}
