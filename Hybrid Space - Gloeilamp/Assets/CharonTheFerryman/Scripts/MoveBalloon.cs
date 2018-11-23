using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBalloon : MonoBehaviour {

    [SerializeField]
    private ArduinoCom com;

    [SerializeField]
    private float speed, burnerPower = 1f;
    [SerializeField]
    private float selfRightingOffset = 1f;
    [SerializeField]
    private GameObject lantern, firePlaceholder;
    [SerializeField]
    private float startTimer;
    [SerializeField]
    private float damping = 10f;
    [SerializeField]
    private float rotSpeed = 90f;

    private Rigidbody rb;
    private bool burner, dropLantern = false;
    private float timer;
    private float desiredRot;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        desiredRot = transform.eulerAngles.y;
    }

    void Update() {
        if (Input.GetKey(KeyCode.Space)) burner = true;
        if (Input.GetKey(KeyCode.L) && timer <= 0) dropLantern = true;
    }

    private void FixedUpdate() {
        //move forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //calculate rotation
        Rotation();
        //player input stuff
        Abilities();
        //self-righting stuff
        Vector3 point = transform.TransformPoint(Vector3.up * selfRightingOffset);
        rb.AddForceAtPosition(Vector3.down, point);
        //custom gravity because baloons
        rb.AddForce(Vector3.down * 0.1f, ForceMode.Acceleration);
    }

    void Rotation() {
        if (com.left || !com.isActiveAndEnabled && Input.GetKey(KeyCode.A)) desiredRot -= rotSpeed * Time.deltaTime;
        if (com.right || !com.isActiveAndEnabled && Input.GetKey(KeyCode.D)) desiredRot += rotSpeed * Time.deltaTime;
        var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, desiredRot, transform.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
    }

    void Abilities() {
        if (burner) {
            //remove - from transforms once model is correct!!! (not 180 flip)
            if (rb.velocity.y < 0) rb.AddForce(-transform.up * (1.8f * burnerPower), ForceMode.Acceleration);
            else rb.AddForce(-transform.up * (0.8f * burnerPower), ForceMode.Acceleration);
            firePlaceholder.SetActive(true);
            burner = false;
        }
        if (dropLantern) {
            Instantiate(lantern, new Vector3(transform.position.x, transform.position.y - 4.5f, transform.position.z), Quaternion.identity);
            timer = startTimer;
            dropLantern = false;
        }
        else timer -= Time.deltaTime;
    }
} 
