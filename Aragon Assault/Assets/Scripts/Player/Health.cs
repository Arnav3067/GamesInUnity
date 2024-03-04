using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    public static Health health {get; private set;}

    [SerializeField] private int playerLives = 3;

    public event EventHandler OnPlayerDestroyed;

    private void Awake() {
        health = this;
    }

    public void Damage() {
        playerLives --;
        if(playerLives < 1) {
            PlayerIsDead();
        }
    }

    private void PlayerIsDead() {
        OnPlayerDestroyed?.Invoke(this, EventArgs.Empty);
        
    }   
}
