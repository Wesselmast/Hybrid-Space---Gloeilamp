using UnityEngine;
using System.Collections;
using VRTK.Controllables;

public class SailController : MonoBehaviour {

    [SerializeField]
    private float steerSpeed = 5f;

    [SerializeField]
    private float accelerateSpeed = 20f;

    [SerializeField]
    private Transform mastBottom;

    [Range(0.0f, 1.4f)]
    public float currentMastSize; // 0.0f, 1.4f

    private float betweenValue = 0.6f;

    [SerializeField]
    private float startRotatingAtVelocity = 0.25f;

    [SerializeField]
    private VRTK_BaseControllable boatOar;

    [SerializeField]
    private VRTK_BaseControllable boatMast;

    bool isRight = false;
    bool isLeft = false;
    bool isMoving = true;

    Rigidbody rb;

    // Use this for initialization
    void Start() {
        rb = GetComponent<Rigidbody>();

        boatOar = (boatOar == null ? GetComponent<VRTK_BaseControllable>() : boatOar);
        boatOar.ValueChanged += ValueChangedOar;

        boatMast = (boatMast == null ? GetComponent<VRTK_BaseControllable>() : boatMast);
        boatMast.ValueChanged += ValueChangedMast;

        //currentMastSize = 1.4f;
    }

    // Update is called once per frame
    private void Update() {

        Debug.Log(rb.velocity.magnitude);

        // Move forward based on the mast's size
        rb.AddForce(transform.forward * accelerateSpeed / (currentMastSize + betweenValue) * Time.deltaTime);

        // Move to the right
        if (isRight && isMoving) {
            rb.AddTorque(0f, 1 * steerSpeed * Time.deltaTime, 0f);
        }

        // Move to the left
        if (isLeft && isMoving) {
            rb.AddTorque(0f, -1 * steerSpeed * Time.deltaTime, 0f);
        }

        // Check if the boat is moving
        if (rb.velocity.magnitude > startRotatingAtVelocity) {
            isMoving = true;
        } else {
            isMoving = false;
        }

        // Update the mast's size based on the wheel's rotation + 0.6f for extra correction
        mastBottom.position = new Vector3(mastBottom.position.x, currentMastSize + 0.6f, mastBottom.position.z);
    }

    // Check in which direction the boat will steer
    protected virtual void ValueChangedOar(object sender, ControllableEventArgs e) {

        if (e.value > 7f) { isRight = true; isLeft = false; }
        if (e.value < 3f) { isLeft = true; isRight = false; }
        if (e.value >= 3 && e.value <= 7) { isLeft = false; isRight = false; }
    }

    // Check the mast's size based on the wheel's rotation
    protected virtual void ValueChangedMast(object sender, ControllableEventArgs e) {

        currentMastSize = e.value / 180; 
    }
}
