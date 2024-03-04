using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{ 
    private TMP_Text scoreText;

    private void Awake() {
        transform.GetChild(0).TryGetComponent(out scoreText);
    }

    private void Update() {
        SetScoreInUI();
    }

    private void SetScoreInUI() {
        string score = ScoreSystem.Instance.score.ToString();
        scoreText.SetText(score, true);
    }
}
