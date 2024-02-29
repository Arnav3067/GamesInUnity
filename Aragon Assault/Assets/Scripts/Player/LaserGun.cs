using UnityEngine;

public class LaserGun : MonoBehaviour
{
    [SerializeField] private GameObject laser;

    private ParticleSystem laserParticleSystem;


    private void Awake() {
        laser.TryGetComponent(out laserParticleSystem);
    }

    public void SetShootingTo(bool value) {

        ParticleSystem.EmissionModule emissionModule = laserParticleSystem.emission;

        # region decision: Which function to call (shoot / StopShoot)

        if (value) {
            Shoot(); 
        } else {
            StopShoot(); 
        }   
    
        # endregion

        void Shoot() {
            emissionModule.enabled = true;
        }

        void StopShoot() {
            emissionModule.enabled  = false;
        }
    }
}
