using UnityEngine;

public class DeathLayer : MonoBehaviour {
    [SerializeField]
    private GameObject[] toDestroy;

    private void OnTriggerEnter(Collider other) {
        for (int i = 0; i < toDestroy.Length; i++) {
            if (other.tag == toDestroy[i].tag) {
                try { other.GetComponent<IDestroyable>().Destroy(); }
                catch(System.Exception) { Debug.LogWarning("You forgot to add an IDestroyable"); }
            }
        }
    }
}
