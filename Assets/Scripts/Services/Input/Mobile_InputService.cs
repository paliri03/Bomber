using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "MobileInputService", menuName = "ScriptableObjects/InputService/MobileInputService")]
public class Mobile_InputService : ScriptableObject, IInputService, PlayerControls.IMobileActions
{
    private PlayerControls playerControls;

    public event Action<Vector2> OnHold;
    public event Action<Vector2> OnTap;

    private Vector2 tochPosition;

    private void OnEnable()
    {
        playerControls = new PlayerControls();
        playerControls.Mobile.Enable();

        playerControls.Mobile.SetCallbacks(this);
    }

    void PlayerControls.IMobileActions.OnHold(InputAction.CallbackContext context)
    {
        if (!IsUIOverlay())
            OnHold?.Invoke(context.ReadValue<Vector2>());
    }

    void PlayerControls.IMobileActions.OnTap(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        { 
            if(!IsUIOverlay())
                OnTap?.Invoke(context.ReadValue<Vector2>());
        }
    }

    public void OnPosition(InputAction.CallbackContext context)
    {
        tochPosition = context.ReadValue<Vector2>();
    }

    private bool IsUIOverlay()
    {
        var eventData = new PointerEventData(EventSystem.current)
        {
            position = tochPosition
        };

        List<RaycastResult> raycastResults = new();
        EventSystem.current.RaycastAll(eventData, raycastResults);

        return raycastResults.Count > 0;
    }

    private void OnDisable()
    {
        playerControls.Mobile.Disable();
    }
}
