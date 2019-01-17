using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerSpeed : MonoBehaviour {

    [SerializeField]
    private BoatEngine boat;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Boat") {
            boat.isSlowed = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.tag == "Boat") {
            boat.isSlowed = false;
        }
    }
}
