using System;
using UnityEngine;

public class Enemy : MonoBehaviour, ICollidable {

    [SerializeField] private int enemyLives = 15;
    [SerializeField] private float selfDestructTimeDelay = 0.08f;
    [SerializeField] private int OnDestroyScoreValue = 30;
    [SerializeField] private int OnHitScoreValue = 1;

    public event EventHandler OnEnemyDestroyed;
    
    private EnemyVFX enemyVFX;

    private void Awake() {
        TryGetComponent(out enemyVFX);
    }

    public void Damage() {
        OnHit();
        if(enemyLives < 1) {
            selfDestructSequence();
        }
    }

    private void OnHit() {
        enemyLives --;
        ScoreSystem.Instance.ScoreUpBy(OnHitScoreValue);
    }

    private void selfDestructSequence() {
        OnEnemyDestroyed?.Invoke(this, EventArgs.Empty);
        ScoreSystem.Instance.ScoreUpBy(OnDestroyScoreValue);
        enemyVFX.PlayEnemyDestroyedVFX();
        Destroy(gameObject, selfDestructTimeDelay);
    }

    
}
