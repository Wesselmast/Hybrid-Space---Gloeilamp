using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class IsBuoyant : MonoBehaviour {

    [SerializeField]
    private float floatHeight = 2f;
    [SerializeField]
    private float bounceDamp = 0.05f;
    [SerializeField]
    private Vector3 buoyancyOffset;
    [SerializeField]
    private float waterLayer;

    private Rigidbody rb;
    private Vector3 actionPoint;
    private Vector3 uplift;
    private FMODCom splashSound;
    private float forceFactor;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private void Start() {
        splashSound = new FMODCom("WaterSplash");
    }

    private void FixedUpdate () {
        actionPoint = transform.position + transform.TransformDirection(buoyancyOffset);
        forceFactor = 1f - ((actionPoint.y - waterLayer) / floatHeight);

        if (forceFactor > 0) {
            splashSound.Play3D(transform, rb);
            uplift = -Physics.gravity * (forceFactor - rb.velocity.y * bounceDamp);
            rb.AddForceAtPosition(uplift, actionPoint);
        }
	}
}
