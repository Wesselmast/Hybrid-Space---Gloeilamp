public class Replay : UnityEngine.MonoBehaviour {
    public void BackToLevel(string levelName) {
        UnityEngine.SceneManagement.SceneManager.LoadScene(levelName);
    }
}
