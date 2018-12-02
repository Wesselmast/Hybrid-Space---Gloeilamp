using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BalloonBurner))]
public class BalloonEngine : MonoBehaviour {

    [SerializeField]
    private float damping = 10.0f;
    [SerializeField]
    private float rotationSpeed = 90.0f;
    [SerializeField]
    private float movementSpeed = 5.0f;

    private float desiredRot;

    void Start () {
        GetComponent<BalloonInput>().OnRotateLeft += RotateLeft;
        GetComponent<BalloonInput>().OnRotateRight += RotateRight;
        desiredRot = transform.eulerAngles.y;
    }

    void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        Quaternion desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, desiredRot, transform.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
    }

    void RotateLeft() { desiredRot -= rotationSpeed * Time.deltaTime; }
    void RotateRight() { desiredRot += rotationSpeed * Time.deltaTime; }
}
