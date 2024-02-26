using System;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float linearVelocity = 20f;
    [SerializeField] private float clampRangeX = 10f;
    [SerializeField] private float clampRangeY = 8f;

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
            
        }

        void _handleLinearMotion(float xInputs, float yInputs)
        {
            // gets clamped direction of the x axis
            float xDir = xInputs * linearVelocity * Time.deltaTime;
            float clampedXDir = Mathf.Clamp(transform.localPosition.x + xDir, -clampRangeX, clampRangeX);

            // gets clamped direction of y axis
            float yDir = yInputs * linearVelocity * Time.deltaTime;
            float yMin = -1f; float yMax = 9f;
            float clampedYDir = Mathf.Clamp(transform.localPosition.y + yDir, yMin, yMax);

            // applies it to the local position
            transform.localPosition = new Vector3(clampedXDir, clampedYDir, 0);
        }
    }
}

