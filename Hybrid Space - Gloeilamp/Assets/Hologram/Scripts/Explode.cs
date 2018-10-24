using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour {

    [SerializeField]
    private float fuseTime;
    [SerializeField]
    private float explosionRadius, explosionForce;
    [SerializeField]
    public GameObject explosion;

    Rigidbody rb;
    GameObject boom;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(LightTheFuses());
    }

    IEnumerator LightTheFuses() {
        if (boom != null) Destroy(boom);
        yield return new WaitForSeconds(fuseTime);
        boom = Instantiate(explosion, transform.position, Quaternion.identity);
        Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, explosionRadius);
        foreach (var c in colliders) {
            Rigidbody cRb = c.GetComponent<Rigidbody>();
            if (cRb != null) {
                Vector3 moveDir = rb.transform.position - cRb.transform.position;
                cRb.AddForce(moveDir.normalized * -explosionForce, ForceMode.Impulse);
            }
        }
        Destroy(gameObject);
    }
}
