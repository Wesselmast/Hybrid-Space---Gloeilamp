using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowController : MonoBehaviour {

    [SerializeField]
    private BoatController boatController;

    private void OnTriggerEnter(Collider other) {

        if (other.tag == "PeddleRight") {
            Debug.Log("going right");
            boatController.isRight = true;
            boatController.isLeft = false;
        }

        if (other.tag == "PeddleLeft") {
            Debug.Log("going left");
            boatController.isRight = false;
            boatController.isLeft = true;
        }
    }
}
