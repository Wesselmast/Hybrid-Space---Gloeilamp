public static class HealthManager {
    private static float health;
    private static string sceneToLose;

    public static void InitHealth(float health, string sceneToLose) {
        HealthManager.health = health;
        HealthManager.sceneToLose = sceneToLose;
    }

    public static void RemoveHealth(float amt) {
        if (health >= 0) health -= amt;
        else Die();
    }

    public static float GetCurrentHealth() {
        return health;
    }

    private static void Die() {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLose);
    }
}
