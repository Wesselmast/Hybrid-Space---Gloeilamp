using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BalloonInput))]
public class BalloonEngine : MonoBehaviour {

    [SerializeField]
    private float damping = 10.0f;
    [SerializeField]
    private float rotationSpeed = 90.0f;
    [SerializeField]
    private float movementSpeed = 5.0f;

    [Header("Steering Wheel")]
    [SerializeField]
    private Transform steeringWheel;
    [SerializeField]
    private float steeringSpeed = 2.0f;

    private float desiredRot, desiredRotWheel;

    void Start () {
        GetComponent<BalloonInput>().OnRotateLeft += RotateLeft;
        GetComponent<BalloonInput>().OnRotateRight += RotateRight;
        desiredRot = transform.eulerAngles.y;
        desiredRotWheel = steeringWheel.localEulerAngles.x;
    }

    void Update () {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        Quaternion desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, desiredRot, transform.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);

        // Moving wheel
        Quaternion desiredRotW = Quaternion.Euler(desiredRotWheel, -90, -90);
        steeringWheel.localRotation = Quaternion.Lerp(steeringWheel.localRotation, desiredRotW, Time.deltaTime * damping);
    }

    void RotateLeft() {
        desiredRot -= rotationSpeed * Time.deltaTime;
        desiredRotWheel += steeringSpeed * rotationSpeed * Time.deltaTime;
    }

    void RotateRight() {
        desiredRot +=  rotationSpeed * Time.deltaTime;
        desiredRotWheel -= steeringSpeed * rotationSpeed * Time.deltaTime;
    }
}
