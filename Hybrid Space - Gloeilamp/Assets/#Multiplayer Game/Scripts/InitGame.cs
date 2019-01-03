using UnityEngine;

public class InitGame : MonoBehaviour {
    [SerializeField]
    private string sceneToLoadOnLose;
    [SerializeField]
    private Vector2 time;

    private void Start() {
        CustomTimer.Init(time.x, time.y, sceneToLoadOnLose);
    }

    private void FixedUpdate() {
        CustomTimer.Tick();
    }
}
