using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyPlayer : MonoBehaviour, IDestroyable {
    public void Destroy() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
