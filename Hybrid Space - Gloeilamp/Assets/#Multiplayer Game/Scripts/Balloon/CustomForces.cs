using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CustomForces : MonoBehaviour {
    public bool selfRighting = true;
    public float selfRightingOffset = 1.0f;
    public bool customGravity = true;
    public float balloonGravity = 0.1f;

    private Rigidbody rb;

    private void Awake() { rb = GetComponent<Rigidbody>(); }

    void Update () {
        if (selfRighting) {
            rb.AddForceAtPosition(Vector3.down, transform.TransformPoint(Vector3.up * -selfRightingOffset));
        }
        if (customGravity) {
            rb.AddForce(Vector3.down * balloonGravity, ForceMode.Acceleration);
        }
    }
}