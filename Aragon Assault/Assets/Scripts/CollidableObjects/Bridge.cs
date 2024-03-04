using UnityEngine;

public class Bridge : MonoBehaviour, ICollidable 
{
    public void Damage() {
        
    }

    private void OnParticleCollision(GameObject other) {
        Damage();
    }
}
