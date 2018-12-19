using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CanExplode : MonoBehaviour {

    public float radius;

    [SerializeField]
    private LayerMask playerLayer;
    [SerializeField]
    private float startExplodeTimer;
    [SerializeField]
    private GameObject explosionParticle;

    private FMODCom com;
    private bool hasExploded = false;
    private float explodeTimer;

    private void Awake() {
        com = new FMODCom("BarrelExplosion");
    }

    private void Start() {
        explodeTimer = startExplodeTimer;
    }

    private void Update() {
        if (explodeTimer <= 0 && !hasExploded) {
            Explode();
            hasExploded = true;
        }
        else explodeTimer -= Time.deltaTime;
    }

    private void Explode() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, playerLayer);
        foreach (Collider col in colliders) {
            try { col.GetComponent<IDestroyable>().Destroy(); }
            catch(System.Exception) { }
        }
        com.Play3D(transform, GetComponent<Rigidbody>());
        GameObject explosion = Instantiate(explosionParticle, transform.position, Quaternion.identity);
        Destroy(explosion, 1.0F);
        Destroy(gameObject);
    }
}
