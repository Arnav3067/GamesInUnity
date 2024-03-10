using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]

public class Enemy : MonoBehaviour, ICollidable {

    // settings
    [SerializeField] private int enemyLives = 15;
    [SerializeField] private int OnDestroyScoreValue = 30;
    [SerializeField] private int OnHitScoreValue = 1;
    [SerializeField] private float timeDilationLength = 1f;
    [SerializeField] private float timeDilationFactor = 0.2f;

    private static float selfDestructTimeDelay = 0.08f;

    // events
    public event EventHandler OnEnemyDestroyed;

    // references
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
        MasterTimeline.Instance.TimeDilation(timeDilationLength, timeDilationFactor);
        ScoreSystem.Instance.ScoreUpBy(OnDestroyScoreValue);
        enemyVFX.PlayEnemyDestroyedVFX();
        Destroy(gameObject, selfDestructTimeDelay);
    }

    
}
