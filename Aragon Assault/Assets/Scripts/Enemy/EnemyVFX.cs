using System;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyVFX : MonoBehaviour
{
    [SerializeField] private GameObject explosionPFX;
    [SerializeField] private Transform spawnAtRuntime;

    public void PlayEnemyDestroyedVFX() {
        GameObject runtimeExplosionPFX = Instantiate(explosionPFX, transform.position, transform.rotation);
        runtimeExplosionPFX.transform.parent = spawnAtRuntime;
        Destroy(runtimeExplosionPFX, 1);
    }

}
