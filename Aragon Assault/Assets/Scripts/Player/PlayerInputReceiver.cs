using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputReceiver : MonoBehaviour
{
    private PlayerInputActions inputActions;

    public event EventHandler OnPlayerShootingStart;
    public event EventHandler OnPlayerShootingStop;
    public event EventHandler OnPlayerBoost;

    private void Awake() {
        inputActions = new PlayerInputActions();
        EnableInputs();
    }

    private void Start() {
        inputActions.Player.Shoot.started += (InputAction.CallbackContext context) => 
            OnPlayerShootingStart?.Invoke(this, EventArgs.Empty);

        inputActions.Player.Shoot.canceled += (InputAction.CallbackContext context ) => 
            OnPlayerShootingStop?.Invoke(this, EventArgs.Empty);

        inputActions.Player.Boost.started += (InputAction.CallbackContext context) => 
            OnPlayerBoost?.Invoke(this, EventArgs.Empty);
    }

    public float GetInputAxisHorizontal() {
        return Input.GetAxis("Horizontal");
    }

    public float GetInputAxisVertical() {
        return Input.GetAxis("Vertical");
    }

    private void EnableInputs() {
        inputActions.Player.Shoot.Enable();
        inputActions.Player.Boost.Enable();
    }

}
