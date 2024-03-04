using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    // serialized private fields
    [SerializeField] private float linearVelocity = 20f;
    [SerializeField] private float angularVelocityVertical = -15f;
    [SerializeField] private float angularVelocityHorizontal = -3f;
    [SerializeField] private float axialAngularVelocity = 2f;
    [SerializeField] private float clampRangeX = 10f;
    [SerializeField] private float clampRangeY = 7f;

    // private fields
    private float positionPitchFactor = -2f;
    private PlayerInputReceiver inputs;
    private LaserGun laserGun;
    private bool controlsActive = true;

    private void Awake() {
        TryGetComponent(out inputs);
        TryGetComponent(out laserGun);
    }
    
    private void Start() {
        inputs.OnPlayerShootingStart += Inputs_OnPlayerShootingStart;
        inputs.OnPlayerShootingStop += Inputs_OnPlayerShootingStop;
    }

    # region OnEventCall function declarations

    private void Inputs_OnPlayerShootingStop(object sender, EventArgs e) {
        if (laserGun != null && controlsActive) {
            laserGun.SetShootingTo(false);
        }
    }

    private void Inputs_OnPlayerShootingStart(object sender, EventArgs e) {
        if (laserGun != null && controlsActive) {
            laserGun.SetShootingTo(true);
        }
    }

    # endregion

    private void Update() {
        if (controlsActive) {
            float xInputs = inputs.GetInputAxisHorizontal();
            float yInputs = inputs.GetInputAxisVertical();
            HandleMovement(xInputs, yInputs);
            HandleRotations(xInputs, yInputs);
        }
    }

    private void HandleMovement(float xInputs, float yInputs)
    {
        float xVelocity = xInputs * linearVelocity * Time.deltaTime;
        float clampedXPos = Mathf.Clamp(transform.localPosition.x + xVelocity, -clampRangeX, clampRangeX);

        float yVelocity = yInputs * linearVelocity * Time.deltaTime;
        float clampedYPos = Mathf.Clamp(transform.localPosition.y + yVelocity, -clampRangeY, clampRangeY);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }

    private void HandleRotations(float xInputs, float yInputs) {

        float pitch = transform.localPosition.y * positionPitchFactor + yInputs * angularVelocityVertical;
        float yaw = transform.localPosition.x * axialAngularVelocity;
        float roll = xInputs * angularVelocityHorizontal;
        
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    public void IncreaseLinearVelocityBy(float amount) {
        linearVelocity += amount;
    }

    public void DecreaseLinearVelocityBy(float amount) {
        linearVelocity -= amount;
    }

    
}

