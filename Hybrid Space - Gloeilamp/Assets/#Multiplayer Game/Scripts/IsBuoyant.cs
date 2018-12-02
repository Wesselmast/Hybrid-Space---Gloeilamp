using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsBuoyant : MonoBehaviour {

    [SerializeField]
    private Transform water;
    [SerializeField]
    private float floatHeight = 2f;
    [SerializeField]
    private float bounceDamp = 0.05f;
    [SerializeField]
    private Vector3 buoyancyOffset;

    private Rigidbody rb;
    private Vector3 actionPoint;
    private Vector3 uplift;
    private float forceFactor;

    private void Start() {
        if (GetComponent<Rigidbody>() != null) rb = GetComponent<Rigidbody>(); 
    }

    void Update () {
        actionPoint = transform.position + transform.TransformDirection(buoyancyOffset);
        forceFactor = 1f - ((actionPoint.y - water.position.y) / floatHeight);

        if (forceFactor > 0) {
            uplift = -Physics.gravity * (forceFactor - rb.velocity.y * bounceDamp);
            rb.AddForceAtPosition(uplift, actionPoint);
        }
	}
}
