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
        GetComponent<BalloonInput>().OnRotateLeftSoft += (()=> Rotate(-1, 1));
        GetComponent<BalloonInput>().OnRotateRightSoft += (() => Rotate(1, 1));
        GetComponent<BalloonInput>().OnRotateLeftHard += (() => Rotate(-1, hardRotateModifier));
        GetComponent<BalloonInput>().OnRotateRightHard += (() => Rotate(1, hardRotateModifier));
        desiredRot = transform.eulerAngles.y;
    }

    private void FixedUpdate () {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed);
        Quaternion desiredRotQ = Quaternion.Euler(transform.eulerAngles.x, desiredRot, transform.eulerAngles.z);
        transform.rotation = Quaternion.Lerp(transform.rotation, desiredRotQ, Time.deltaTime * damping);
    }

    private void Rotate(int direction, float hardModifier) {
        desiredRot += rotationSpeed * direction * Time.deltaTime * hardModifier;
    }
}
