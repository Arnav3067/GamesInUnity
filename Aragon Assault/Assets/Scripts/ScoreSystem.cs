using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem Instance {get; private set;}

    public int score {get; private set;} = 0;

    private void Awake() {
        Instance = this;
    }

    public void ScoreDownBy(int amount) {
        score -= amount;
    }

    public void ScoreUpBy(int amount) {
        score += amount;
    }

}
