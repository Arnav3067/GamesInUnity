using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float linearVelocity = 20f;
    [SerializeField] private float angularVelocityVertical = -15f;
    [SerializeField] private float angularVelocityHorizontal = -3f;
    [SerializeField] private float axialAngularVelocity = 2f;
    [SerializeField] private float clampRangeX = 10f;
    [SerializeField] private float clampRangeY = 7f;

    private PlayerInputReceiver inputs;

    private void Awake() {
        TryGetComponent(out inputs);
    }

    private void Update() {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float xInputs = inputs.GetInputAxisHorizontal();
        float yInputs = inputs.GetInputAxisVertical();

        _handleLinearMotion(xInputs, yInputs);
        _handleRotations(xInputs, yInputs);

        void _handleRotations(float xInputs, float yInputs) {

            float pitch = transform.localPosition.y * angularVelocityVertical + yInputs;
            float yaw = transform.localPosition.x * axialAngularVelocity;
            float roll = transform.localPosition.x * angularVelocityHorizontal + xInputs;

            transform.localRotation = Quaternion.Euler(pitch, yaw, roll);

        }

        void _handleLinearMotion(float xInputs, float yInputs)
        {
            // gets clamped direction of the x axis
            float xDir = xInputs * linearVelocity * Time.deltaTime;
            float clampedXDir = Mathf.Clamp(transform.localPosition.x + xDir, -clampRangeX, clampRangeX);

            // gets clamped direction of y axis
            float yDir = yInputs * linearVelocity * Time.deltaTime;
            float clampedYDir = Mathf.Clamp(transform.localPosition.y + yDir, -clampRangeY, clampRangeY);

            // applies it to the local position
            transform.localPosition = new Vector3(clampedXDir, clampedYDir, 0);
        }
    }
}

