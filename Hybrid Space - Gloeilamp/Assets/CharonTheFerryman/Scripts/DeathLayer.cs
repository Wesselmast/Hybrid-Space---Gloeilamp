using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathLayer : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Latern") Destroy(other.gameObject);
        if (other.tag == "Player") SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
