using UnityEngine;

public class Finish : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Boat") {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Win");
        }
    }
}
