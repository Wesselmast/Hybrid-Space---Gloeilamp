using UnityEngine;

public class Finish : MonoBehaviour {

    [SerializeField]
    private WinLosePackage pack;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Boat") {
            pack.Win();
        }
    }
}
