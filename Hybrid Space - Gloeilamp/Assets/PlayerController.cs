using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed, turnSpeed;

    private bool rotateLeft, rotateRight = false;

    private void Update() {
        if (Input.GetKey(KeyCode.A)) rotateLeft = true;
        if (Input.GetKey(KeyCode.D)) rotateRight = true;
    }

    private void FixedUpdate () {
        transform.Translate(0, 0, speed * Time.deltaTime);
        if (rotateLeft) {
            gameObject.transform.localEulerAngles += new Vector3(0, -turnSpeed, 0);
            rotateLeft = false;
        }
        if (rotateRight) {
            gameObject.transform.localEulerAngles += new Vector3(0, turnSpeed, 0);
            rotateRight = false;
        }
    }
}
    