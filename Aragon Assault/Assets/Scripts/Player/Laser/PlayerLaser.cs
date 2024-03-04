using UnityEngine;

public class PlayerLaser : MonoBehaviour
{

    private void OnParticleCollision(GameObject other) {
        if (other.transform.TryGetComponent(out ICollidable collidable)) {
            collidable.Damage();
            DestroyLaserVFX();
        }
    }

    private void DestroyLaserVFX() {
        
    }
}