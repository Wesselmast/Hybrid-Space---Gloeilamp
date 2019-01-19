using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CanExplode : MonoBehaviour {
    private enum BarrelType {
        InstantBarrel,
        DelayedBarrel
    }
    [Header("Barrel Type")]
    [SerializeField]
    private BarrelType barrelType;

    [Header("Barrel Stats")]
    public float radius;
    [SerializeField]
    private float startExplodeTimer;
    [SerializeField]
    private LayerMask playerLayer;
    [SerializeField]
    private GameObject explosionParticle;

    private FMODCom com;
    private Rigidbody rb;
    private IBarrel barrel;
    private Explode explode;

    private void Awake() {
        com = new FMODCom("BarrelExplosion");
        rb = GetComponent<Rigidbody>();
        switch (barrelType) {
            case BarrelType.InstantBarrel:
                barrel = new InstantBarrel(transform);
                break;
            case BarrelType.DelayedBarrel:
                barrel = new DelayedBarrel(startExplodeTimer);
                break;
        }
        explode = Explode;
    }

    private void Update() {
        barrel.Tick(explode);
    }

    private void Explode() {
        com.Play3D(transform, rb);
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, playerLayer);
        foreach (Collider col in colliders) {
            try { col.GetComponent<IDestroyable>().Destroy(); }
            catch { Debug.Log("IDestroyable component not found!"); }
        }
        GameObject particle = Instantiate(explosionParticle, transform.position, Quaternion.identity);
        Destroy(particle, 1f);
        Destroy(gameObject);
    }
}