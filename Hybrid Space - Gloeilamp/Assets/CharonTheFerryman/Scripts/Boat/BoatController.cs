using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour {

    [SerializeField]
    private float speed;
    [SerializeField]
    private float damping = 10f;
    [SerializeField]
    private float rotSpeed = 90f;

    private float desiredRot;

    public bool isRight = false;
    public bool isLeft = false;

    private void Start() {
        desiredRot = transform.eulerAngles.y;
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (isRight) GoRight();
        if (isLeft) GoLeft();
    }

    public void GoLeft() {
        desiredRot += rotSpeed * Time.deltaTime;

        var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, desiredRot, transform.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
    }

    private void GoRight() {
        desiredRot -= rotSpeed * Time.deltaTime;

        var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, desiredRot, transform.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
    }
}
