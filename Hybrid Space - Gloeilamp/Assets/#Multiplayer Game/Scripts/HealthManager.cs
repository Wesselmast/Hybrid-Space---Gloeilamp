using UnityEngine;

public static class HealthManager {
    private static float health;
    private static string sceneToLose;
    private static WinLosePackage pack;

    public static void InitHealth(float health, string sceneToLose, WinLosePackage pack) {
        HealthManager.health = health;
        HealthManager.sceneToLose = sceneToLose;
        HealthManager.pack = pack;
    }

    public static void RemoveHealth(float amt) {
        if (health >= 0) health -= amt;
        else Die();
    }

    public static float GetCurrentHealth() {
        return health;
    }

    private static void Die() {
        pack.Lose();
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLose);
    }
}

[System.Serializable]
public struct WinLosePackage {
    [SerializeField]
    private GameObject loseBoat, victoryBoat, loseBalloon, victoryBalloon;
    [SerializeField]
    private BoatEngine engine;
    [SerializeField]
    private BalloonInput input;
    [SerializeField]
    private BalloonEngine balEngine;
    [SerializeField]
    private CustomForces forces;

    public void Lose() {
        loseBoat.SetActive(true);
        victoryBalloon.SetActive(true);
        engine.enabled = false;
        input.enabled = false;
        balEngine.enabled = false;
        forces.enabled = false;
    }

    public void Win() {
        victoryBoat.SetActive(true);
        loseBalloon.SetActive(true);
        engine.enabled = false;
        input.enabled = false;
        balEngine.enabled = false;
        forces.enabled = false;
    }
}
