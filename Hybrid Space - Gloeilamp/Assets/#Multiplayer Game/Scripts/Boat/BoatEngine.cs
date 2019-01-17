using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(EnableVR))]
public class BoatEngine : MonoBehaviour {

    [Header("Boat Settings")]
    public float accelerationSpeed = 1f;
    [SerializeField]
    private float steerSpeed = 2f;
    [SerializeField]
    private float damping = 10f;
    [SerializeField]
    private float floatHeight = 7.1f;
    [SerializeField]
    private bool allowTilting = true;
    [SerializeField]
    private float tiltLimit = 10f;
    [HideInInspector]
    public bool isSlowed = false;
    [Header("Sail Settings")]
    [SerializeField]
    private bool allowSailRotation = true;
    [SerializeField]
    private float sailRotLimit = 60f;
    //[SerializeField]
    //private Transform mainSail;

    public CircularDrive steeringDrive;
    private float desiredRotY, desiredRotZ;
    private float sailRotY;
    private bool vrEnabled;
    private Rigidbody rb;
    private EnableVR checkVR;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        checkVR = GetComponent<EnableVR>();
    }

    private void Start() {
        desiredRotY = transform.eulerAngles.y;
        desiredRotZ = transform.eulerAngles.z;
        //sailRotY = mainSail.localEulerAngles.y;
        vrEnabled = checkVR.enableVR ? true : false;
    }

    private void FixedUpdate() {
        Movement();
        Steering();
        RotateSail();
    }

    // Move forward based on acceleration speed
    private void Movement() {
        rb.velocity = -transform.forward * accelerationSpeed * Time.deltaTime;
    }

    // Check in which direction the boat will steer
    private void Steering() {

        // If enabledVR is not checked
        if (!vrEnabled) {
            float rotation = Input.GetAxis("Horizontal");
            transform.Rotate(0, rotation * steerSpeed, 0);
        } 
        
        // If enabledVR is checked
        else {
            desiredRotY += steerSpeed * -steeringDrive.outAngle * Time.deltaTime;

            if (allowTilting) {
                desiredRotZ += -steeringDrive.outAngle * Time.deltaTime;
                desiredRotZ = Mathf.Clamp(desiredRotZ, -tiltLimit, tiltLimit);
            }

            var desiredRotQ = Quaternion.Euler(0, desiredRotY, Mathf.Clamp(desiredRotZ, -tiltLimit, tiltLimit));
            transform.rotation = Quaternion.Slerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
        } 
    }

    // Rotate the main sail based on the direction in which the boat is steering
    private void RotateSail() {
        if (allowSailRotation) {
            sailRotY += -steeringDrive.outAngle * Time.deltaTime;
            sailRotY = Mathf.Clamp(sailRotY, -sailRotLimit, sailRotLimit);

            var sailRotQ = Quaternion.Euler(0, sailRotY, 0);
            //mainSail.localRotation = Quaternion.Slerp(mainSail.localRotation, sailRotQ, Time.deltaTime * damping);
        }
    }
}
