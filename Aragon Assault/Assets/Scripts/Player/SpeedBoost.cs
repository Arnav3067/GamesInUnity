using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;


public class SpeedBoost : MonoBehaviour
{
    // class customization fields
    [Header("Settings")]
    [SerializeField] private float speedIncreaseAmount = 20;
    [SerializeField] private float timeUntilReuse = 10f;
    [SerializeField] private float speedBoostDuration = 3f;
    [SerializeField] private float cameraShakeIntensity = 9f;

    // references
    private PlayerInputReceiver inputs;
    private Player player;
    private PlayerVFX playerVFX;

    // events
    public static event EventHandler OnSpeedBoostUsed;
    public static event EventHandler onSpeedBoostReusable;

    private void Awake() {
        TryGetComponent(out inputs);
        TryGetComponent(out player);
        TryGetComponent(out playerVFX);
    }

    private void Start() {
        SetSpeedBoostInputsActive(true);
    }

    private void Inputs_OnPlayerBoost(object sender, EventArgs e) {
        StartCoroutine(SpeedBoostRoutine());
    } 

    private IEnumerator SpeedBoostRoutine()
    {
        EnableSpeedBoost();
        yield return new WaitForSeconds(speedBoostDuration);
        DisableSpeedBoost();
        yield return new WaitForSeconds(timeUntilReuse);
        SetSpeedBoostInputsActive(true);
    }


    private void EnableSpeedBoost() {
        OnSpeedBoostUsed?.Invoke(this, EventArgs.Empty);
        SetSpeedBoostInputsActive(false);
        playerVFX.VFXOnSpeedBoostIn(speedBoostDuration, cameraShakeIntensity);
        player.IncreaseLinearVelocityBy(speedIncreaseAmount);   
    }

    private void DisableSpeedBoost() {
        onSpeedBoostReusable?.Invoke(this, EventArgs.Empty);
        playerVFX.VFXOnSpeedBoostOut();
        player.DecreaseLinearVelocityBy(speedIncreaseAmount);
    }

    private void SetSpeedBoostInputsActive(bool areActive) {
        if (areActive) {
            inputs.OnPlayerBoost += Inputs_OnPlayerBoost;
        } else {
            inputs.OnPlayerBoost -= Inputs_OnPlayerBoost;
        }
    }

}

