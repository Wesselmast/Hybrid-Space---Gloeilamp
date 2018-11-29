using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBalloon : MonoBehaviour
{

    [SerializeField]
    [Header("Movement")]
    private float damping = 10f;
    [SerializeField]
    private float rotSpeed = 90f;
    [SerializeField]
    private float selfRightingOffset = 1f;
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float burnerPower = 1f;
    [SerializeField]
    [Range(0, 5)]
    private float balloonGravity = 0.1f;

    [Header("Misc")]
    [SerializeField]
    private Transform dropSpot;
    [SerializeField]
    private ArduinoCom com;
    [SerializeField]
    private GameObject lantern;
    [SerializeField]
    private GameObject firePlaceholder;
    [SerializeField]
    private float startTimer;

    private Rigidbody rb;
    private bool burner, dropLantern = false;
    private float timer;
    private float desiredRot;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        desiredRot = transform.eulerAngles.y;
    }

    void Update()
    {
        if (com.up || !com.isActiveAndEnabled && Input.GetKey(KeyCode.Space)) burner = true;
        if ((com.barrels || !com.isActiveAndEnabled && Input.GetKey(KeyCode.B)) && timer <= 0) dropLantern = true;
    }

    private void FixedUpdate()
    {
        //move forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
        //calculate rotation
        Rotation();
        //player input stuff
        Abilities();
        //self-righting stuff
        rb.AddForceAtPosition(Vector3.down, transform.TransformPoint(Vector3.up * selfRightingOffset));
        //custom gravity because baloons
        rb.AddForce(Vector3.down * balloonGravity, ForceMode.Acceleration);
    }

    void Rotation()
    {
        if (com.left || !com.isActiveAndEnabled && Input.GetKey(KeyCode.A)) desiredRot -= rotSpeed * Time.deltaTime;
        if (com.right || !com.isActiveAndEnabled && Input.GetKey(KeyCode.D)) desiredRot += rotSpeed * Time.deltaTime;
        var desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, desiredRot, transform.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
    }

    void Abilities()
    {
        if (burner)
        {
            //remove - from transforms once model is correct!!! (not 180 flip)
            if (rb.velocity.y < 0) rb.AddForce(-transform.up * (1.4f * burnerPower), ForceMode.Acceleration);
            else rb.AddForce(-transform.up * (0.8f * burnerPower), ForceMode.Acceleration);
            firePlaceholder.SetActive(true);
            burner = false;
        }
        if (dropLantern)
        {
            Instantiate(lantern, dropSpot.position, Quaternion.identity);
            timer = startTimer;
            dropLantern = false;
        }
        else timer -= Time.deltaTime;
    }
}
