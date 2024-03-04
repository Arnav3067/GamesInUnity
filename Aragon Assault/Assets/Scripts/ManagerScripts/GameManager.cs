using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // singleton definition bellow
    public static GameManager Instance {get; private set;}

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        Health.health.OnPlayerDestroyed += Player_OnPlayerDestroyed;
    }

    private void Player_OnPlayerDestroyed(object sender, EventArgs e) {
        Invoke(nameof(GameOver), 5);
    }

    private void GameOver() {
        Loader.RestartLevel();
    }
}
