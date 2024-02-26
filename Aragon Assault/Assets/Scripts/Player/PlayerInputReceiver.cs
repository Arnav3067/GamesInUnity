using UnityEngine;

public class PlayerInputReceiver : MonoBehaviour
{
    private PlayerInputActions inputActions;

    private void Awake() {
        inputActions = new PlayerInputActions();
        EnableInputs();
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
    }
}
