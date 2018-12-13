using UnityEngine;
using System;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    [SerializeField]
    private int time;
    [SerializeField]
    private string timeOverSceneName;

    private Text timerText;

    private void Start() {
        timerText = GetComponent<Text>();
        GlobalCountDown.StartCountDown(TimeSpan.FromMinutes(time));
    }

    private void FixedUpdate () {
        int mins = (int)GlobalCountDown.TimeLeft.TotalMinutes;
        int secs = Mathf.FloorToInt((float)GlobalCountDown.TimeLeft.TotalSeconds % 60f);
        timerText.text = mins.ToString("00") + ":" + secs.ToString("00");
        if (mins <= 0 && secs == 0) UnityEngine.SceneManagement.SceneManager.LoadScene(timeOverSceneName);
	}
}
