using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Timer : MonoBehaviour {
    private Text timerText;

    private void Awake() {
        timerText = GetComponent<Text>();   
    }

    private void FixedUpdate() {
        timerText.text = CustomTimer.MinutesLeft.ToString("00") + ":" + CustomTimer.SecondsLeft.ToString("00");
    }
}