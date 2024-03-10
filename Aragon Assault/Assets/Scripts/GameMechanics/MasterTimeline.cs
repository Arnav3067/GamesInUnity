using UnityEngine.Playables;
using UnityEngine;

[RequireComponent(typeof(PlayableDirector))]

public class MasterTimeline : MonoBehaviour
{
    private float timeDilationLength = 1;

    public static MasterTimeline Instance {get; private set;}

    private PlayableDirector masterTimelineDirector;

    private void Update() {
        Time.timeScale += 1/timeDilationLength * Time.unscaledDeltaTime;
        Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }

    private void Awake() {
        Instance = this;
        masterTimelineDirector = GetComponent<PlayableDirector>();
    }

    private void Pause() {
        masterTimelineDirector.Pause();
    }

    public void TimeDilation(float length, float factor) {
        timeDilationLength = length;
        Time.timeScale = factor;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    private void Resume() {
        masterTimelineDirector.Resume();
    }

}
