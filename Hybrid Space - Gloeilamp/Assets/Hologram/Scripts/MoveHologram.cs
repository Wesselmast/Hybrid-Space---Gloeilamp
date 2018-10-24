using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHologram : MonoBehaviour {

    [SerializeField]
    private float speed;

    void Update () {
        if (Input.GetKey(KeyCode.A)) transform.Translate(Vector3.left * speed);
        if (Input.GetKey(KeyCode.D)) transform.Translate(Vector3.right * speed);
        if (Input.GetKey(KeyCode.S)) transform.Translate(Vector3.back * speed);
        if (Input.GetKey(KeyCode.W)) transform.Translate(Vector3.forward * speed);
        if (Input.GetKey(KeyCode.E)) transform.Translate(Vector3.down * speed);
        if (Input.GetKey(KeyCode.Q)) transform.Translate(Vector3.up * speed);
    }
} 
