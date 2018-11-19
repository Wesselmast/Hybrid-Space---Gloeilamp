using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBalloon : MonoBehaviour {

    [SerializeField]
    private float speed, burnerPower = 1f;
    [SerializeField]
    private float selfRightingOffset = 1f;
    [SerializeField]
    private GameObject lantern;
    [SerializeField]
    private float startTimer;

    private Rigidbody rb;
    private Vector3 direction;
    private bool burner, dropLantern = false;
    private float timer;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void Update() {
        direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        Debug.Log(transform.position.y);
        if (Input.GetKey(KeyCode.Space)) burner = true;
        if (Input.GetKey(KeyCode.L) && timer <= 0) dropLantern = true;
    }

    private void FixedUpdate() {
        rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        Vector3 point = transform.TransformPoint(Vector3.up * selfRightingOffset);
        rb.AddForceAtPosition(Vector3.down, point);
        if (burner) {
            //remove - from transforms once model is correct!!! (not 180 flip)
            if (rb.velocity.y < 0) rb.AddForce(-transform.up * burnerPower, ForceMode.Acceleration);
            else rb.AddForce(-transform.up * (0.8f * burnerPower), ForceMode.Acceleration); 
            burner = false;
        }
        if (dropLantern) {
            Instantiate(lantern, new Vector3(transform.position.x, transform.position.y - 4.5f, transform.position.z), Quaternion.identity);
            timer = startTimer;
            dropLantern = false;
        }
        else timer -= Time.deltaTime;
        rb.AddForce(Vector3.down * 0.1f, ForceMode.Acceleration);
    }
} 
