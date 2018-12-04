using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanExplode : MonoBehaviour {
    [SerializeField]
    private LayerMask playerLayer;
    [SerializeField]
    private float startExplodeTimer;
    public float radius;
    [SerializeField]
    private GameObject explosionParticle;

    private float explodeTimer;

    private void Start() {
        explodeTimer = startExplodeTimer;
    }

    private void Update() {
        if (explodeTimer <= 0) {
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius, playerLayer);
            foreach (Collider col in colliders) col.GetComponent<IDestroyable>().Destroy();
            GameObject part = Instantiate(explosionParticle, transform.position, Quaternion.identity);
            Destroy(part, 2f);
            Destroy(gameObject);
        }
        else explodeTimer -= Time.deltaTime;
    }
}
