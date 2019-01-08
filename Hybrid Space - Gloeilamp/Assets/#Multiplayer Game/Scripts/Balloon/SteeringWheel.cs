using UnityEngine;

//LATER ON WORK WITH COMPOSITION!!
public class SteeringWheel : MonoBehaviour {
    [SerializeField]
    private Transform balloon;
    [SerializeField]
    private float steeringSpeed = 2.0f;

    private BalloonEngine engine;
    private float desiredRot;

    private void Start () {
        balloon.GetComponent<BalloonInput>().OnRotateLeftSoft += RotateLeft;
        balloon.GetComponent<BalloonInput>().OnRotateRightSoft += RotateRight;
        engine = balloon.GetComponent<BalloonEngine>();
        desiredRot = transform.localEulerAngles.x;
    }

    private void FixedUpdate () {
        Quaternion desiredRotQ = Quaternion.Euler(desiredRot, -90, -90);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, desiredRotQ, Time.deltaTime * engine.Damping);
    }

    private void RotateLeft() {
        desiredRot += steeringSpeed * engine.RotationSpeed * Time.deltaTime;
    }

    private void RotateRight() {
        desiredRot -= steeringSpeed * engine.RotationSpeed * Time.deltaTime;
    }
}
