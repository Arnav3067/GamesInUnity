using System;
using System.Collections;
using UnityEngine;


public class SpeedBoost : MonoBehaviour
{
    [SerializeField] private float speedIncreaseAmount = 20;
    [SerializeField] private float timeUntilReuse = 10f;
    [SerializeField] private float speedBoostDuration = 3f;
    [SerializeField] private float cameraShakeIntensity = 9f;
    [SerializeField] private Animator camAnimator;

    private PlayerInputReceiver inputs;
    private Player player;

    private void Awake() {
        TryGetComponent(out inputs);
        TryGetComponent(out player);
    }

    private void Start() {
        inputs.OnPlayerBoost += Inputs_OnPlayerBoost;
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
        inputs.OnPlayerBoost += Inputs_OnPlayerBoost;

    }

    private void EnableSpeedBoost() {
        inputs.OnPlayerBoost -= Inputs_OnPlayerBoost;
        camAnimator.SetTrigger("SpeedBoostIn");
        player.IncreaseLinearVelocityBy(speedIncreaseAmount);
        CameraShake.instance.Shake(speedBoostDuration, cameraShakeIntensity);
    }

    private void DisableSpeedBoost() {
        camAnimator.SetTrigger("SpeedBoostOut");
        player.DecreaseLinearVelocityBy(speedIncreaseAmount);
    }

}

