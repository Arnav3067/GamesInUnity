using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.transform.TryGetComponent(out ICollidable collidable)) {
            Health.health.Damage();
            collidable.Damage();
        }
    }
}
