using UnityEngine;

public class HasHealth : MonoBehaviour {
    [SerializeField]
    private float health;
    [SerializeField]
    private string sceneToLose;

    private void Awake() {
        HealthManager.InitHealth(health, sceneToLose);
    }
}