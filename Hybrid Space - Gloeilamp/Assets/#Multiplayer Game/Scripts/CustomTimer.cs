using UnityEngine;
using UnityEngine.SceneManagement;

public static class CustomTimer {
    public static float TotalSeconds { get; set; }
    public static float MinutesLeft, SecondsLeft;

    private static string sceneToLoadOnLose;

    public static void Init(float mins, float secs, string sceneToLoadOnLose) {
        TotalSeconds = secs + (mins * 60);
        CustomTimer.sceneToLoadOnLose = sceneToLoadOnLose;
    }

    public static void Tick() {
        MinutesLeft = Mathf.FloorToInt(TotalSeconds / 60f);
        SecondsLeft = Mathf.FloorToInt(TotalSeconds % 60f);
        TotalSeconds -= Time.deltaTime;
        if (MinutesLeft <= 0 && CustomTimer.SecondsLeft <= 0) SceneManager.LoadScene(sceneToLoadOnLose);
    }
}
