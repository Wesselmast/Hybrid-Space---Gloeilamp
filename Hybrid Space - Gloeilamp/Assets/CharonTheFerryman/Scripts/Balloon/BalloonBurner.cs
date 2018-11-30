using System;
using UnityEngine;

[RequireComponent(typeof(BalloonInput))]
public class BalloonBurner : MonoBehaviour {

    [SerializeField]
    private float burnerPower = 1.0f;

    private Rigidbody rb;
    private BalloonInput input;

    public event Action<bool> OnBurn = delegate{ };

    void Start () {
        input = GetComponent<BalloonInput>();
        rb = GetComponent<Rigidbody>();
	}

    void FixedUpdate() {
        if (input.GoingUp) {
            OnBurn(true);
            if (rb.velocity.y > 0.0f) rb.AddForce(transform.up * (1.4f * burnerPower), ForceMode.Acceleration);
            else rb.AddForce(transform.up * (0.8f * burnerPower), ForceMode.Acceleration);
        }
        else OnBurn(false);
    }
}
