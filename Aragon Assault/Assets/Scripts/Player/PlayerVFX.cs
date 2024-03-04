using System;
using UnityEngine;

public class PlayerVFX : MonoBehaviour
{
    [SerializeField] private GameObject shipParts_RB, shipParts_Normal, explosionPFX;

    private void Start() {
        Health.health.OnPlayerDestroyed += Player_OnPlayerDestroyed;
    }

    private void Player_OnPlayerDestroyed(object sender, EventArgs e) {
        PlayerDestructionSequence();
    }

    private void PlayerDestructionSequence() {
        shipParts_Normal.SetActive(false);
        Instantiate(explosionPFX, transform.position, transform.localRotation);
        shipParts_RB.SetActive(true);
    }
}
