using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 MovementValue { get; private set; } 

    public event Action onTarget;
    public event Action onCancel;
    Controls _controls;
    void Start()
    {
        _controls = new Controls();
        _controls.Player.SetCallbacks(this);
        _controls.Player.Enable();
    }

    private void OnDestroy() => _controls.Player.Disable();


    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnTarget(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            onTarget?.Invoke();
        }
    }

    public void OnCancel(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            onCancel?.Invoke();
        }
    }
}
