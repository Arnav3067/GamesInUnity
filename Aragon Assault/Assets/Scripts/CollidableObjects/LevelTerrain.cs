using UnityEngine;

public class LevelTerrain : MonoBehaviour, ICollidable
{
    public void Damage() {
        print($"{gameObject} has been hit by the player");
    }
}
