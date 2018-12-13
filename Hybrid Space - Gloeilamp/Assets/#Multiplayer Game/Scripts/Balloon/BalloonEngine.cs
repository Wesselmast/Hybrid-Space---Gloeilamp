using UnityEngine;

[RequireComponent(typeof(BalloonInput))]
public class BalloonEngine : MonoBehaviour {
    [SerializeField]
    private float damping = 10.0f;
    public float Damping { get { return damping; } }
    [SerializeField]
    private float rotationSpeed = 90.0f;
    public float RotationSpeed { get { return rotationSpeed; } }
    [SerializeField]
    private float movementSpeed = 5.0f;

    private float desiredRot;

    private void Start () {
        GetComponent<BalloonInput>().OnRotateLeft += RotateLeft;
        GetComponent<BalloonInput>().OnRotateRight += RotateRight;
        desiredRot = transform.eulerAngles.y;
    }

    private void FixedUpdate () {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        Quaternion desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, desiredRot, transform.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
    }

    private void RotateLeft() {
        desiredRot -= rotationSpeed * Time.deltaTime;
    }

    private void RotateRight() {
        desiredRot += rotationSpeed * Time.deltaTime;
    }
}
