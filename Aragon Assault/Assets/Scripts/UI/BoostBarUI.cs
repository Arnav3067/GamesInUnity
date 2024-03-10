using UnityEngine;
using System;


public class BoostBarUI : MonoBehaviour
{
    private Animator barAnimator;

    private void Awake() {
        TryGetComponent(out barAnimator);
    }

    private void Start() {
        SpeedBoost.OnSpeedBoostUsed += (object sender, EventArgs e) => 
            SpeedBoostUsed();

        SpeedBoost.onSpeedBoostReusable += (object sender, EventArgs e) => 
            SpeedBoostReusable();
    }

    private void SpeedBoostUsed() {
        barAnimator.SetTrigger("BoostBarEmpty");
    }

    private void SpeedBoostReusable() {
        barAnimator.SetTrigger("BoostBarFilling");
    }

    
}
