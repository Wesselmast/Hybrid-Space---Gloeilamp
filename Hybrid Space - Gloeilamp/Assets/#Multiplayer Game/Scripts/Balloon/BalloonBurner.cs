using System;
using UnityEngine;

[RequireComponent(typeof(BalloonInput))]
public class BalloonBurner : MonoBehaviour {

    [SerializeField]
    private float burnerPower = 1.0f;

    private Rigidbody rb;
    private BalloonInput input;
    private FMODCom burnerSound;

    public event Action<bool> OnBurn = delegate{ };

    void Awake () {
        input = GetComponent<BalloonInput>();
        rb = GetComponent<Rigidbody>();
	}

    private void Start() {
        burnerSound = new FMODCom("BalloonBurner");
    }

    void FixedUpdate() {
        if (input.GoingUp) {
            OnBurn(true);
            burnerSound.SetParameter("Burning", 1f);
            burnerSound.Play3D(transform, rb);
            if (rb.velocity.y > 0.0f) rb.AddForce(transform.up * (1.4f * burnerPower), ForceMode.Acceleration);
            else rb.AddForce(transform.up * (0.8f * burnerPower), ForceMode.Acceleration);
        }
        else {
            burnerSound.SetParameter("Burning", 0f);
            OnBurn(false);
        }
    }
}