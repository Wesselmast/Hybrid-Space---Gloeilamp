using UnityEngine;

public class InitGame : MonoBehaviour {
    [SerializeField]
    private float mins, secs;
    [SerializeField]
    private string sceneToLoadOnLose;
    [SerializeField]
    private GameObject boat, balloon;

    private void Start() {
        CustomTimer.Init(mins, secs, sceneToLoadOnLose);
    }

    private void FixedUpdate() {
        CustomTimer.Tick();
    }
}
