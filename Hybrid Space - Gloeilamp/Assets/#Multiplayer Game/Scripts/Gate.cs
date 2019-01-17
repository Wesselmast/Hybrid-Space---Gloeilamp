using UnityEngine;

public class Gate : MonoBehaviour {

    [SerializeField]
    private Animation openGate;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Boat") {
            openGate.Play();
            Destroy(gameObject);
        }
    }
}
