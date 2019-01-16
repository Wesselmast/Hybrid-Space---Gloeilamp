using UnityEngine;

public class HasHealth : MonoBehaviour {
    [SerializeField]
    private float health;
    [SerializeField]
    private string sceneToLose;
    [SerializeField]
    private WinLosePackage pack;

    private void Awake() {
        HealthManager.InitHealth(health, sceneToLose, pack);
    }
}