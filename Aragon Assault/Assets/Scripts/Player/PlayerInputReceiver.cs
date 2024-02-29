using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReceiver : MonoBehaviour
{
    private PlayerInputActions inputActions;

    public event EventHandler OnPlayerShootingStart;
    public event EventHandler OnPlayerShootingStop;


    private void Awake() {
        inputActions = new PlayerInputActions();
        EnableInputs();
    }

    private void Start() {
        inputActions.Player.Shoot.started += (InputAction.CallbackContext context) => 
            OnPlayerShootingStart?.Invoke(this, EventArgs.Empty);

        inputActions.Player.Shoot.canceled += (InputAction.CallbackContext context ) => 
            OnPlayerShootingStop?.Invoke(this, EventArgs.Empty);
    }

    public float GetInputAxisHorizontal() {
        return inputActions.Player.XMovement.ReadValue<float>();
    }

    public float GetInputAxisVertical() {
        return inputActions.Player.YMovement.ReadValue<float>();
    }

    private void EnableInputs() {
        inputActions.Player.XMovement.Enable();
        inputActions.Player.YMovement.Enable();
        inputActions.Player.Shoot.Enable();
    }
}
