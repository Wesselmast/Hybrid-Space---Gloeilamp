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
    public float MovementSpeed { get { return movementSpeed; } set { movementSpeed = value; } }

    [SerializeField]
    private float hardRotateModifier;

    private float desiredRot;

    private void Start () {
        GetComponent<BalloonInput>().OnRotateLeftSoft += RotateLeftSoft;
        GetComponent<BalloonInput>().OnRotateRightSoft += RotateRightSoft;
        GetComponent<BalloonInput>().OnRotateLeftHard += RotateLeftHard;
        GetComponent<BalloonInput>().OnRotateRightHard += RotateRightHard;
        desiredRot = transform.eulerAngles.y;
    }

    private void FixedUpdate () {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        Quaternion desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, desiredRot, transform.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
    }

    private void RotateLeftSoft() {
        desiredRot -= rotationSpeed * Time.deltaTime;
    }

    private void RotateRightSoft() {
        desiredRot += rotationSpeed * Time.deltaTime;
    }

    private void RotateLeftHard() {
        desiredRot -= rotationSpeed * Time.deltaTime * hardRotateModifier;
    }

    private void RotateRightHard() {
        desiredRot += rotationSpeed * Time.deltaTime * hardRotateModifier;
    }
}
