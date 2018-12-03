using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanExplode : MonoBehaviour {
    [SerializeField]
    private LayerMask playerLayer;
    [SerializeField]
    private float startExplodeTimer;
    public float radius;

    private float explodeTimer;

    private void Start() {
        explodeTimer = startExplodeTimer;
    }

    private void Update() {
        if (explodeTimer <= 0) {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius, playerLayer);
            foreach (Collider col in colliders) col.GetComponent<IDestroyable>().Destroy();
            Destroy(gameObject);
        }
        else explodeTimer -= Time.deltaTime;
    }
}
