using UnityEngine;

public class InstantBarrel : IBarrel {
    private readonly Transform transform;

    public InstantBarrel(Transform transform) {
        this.transform = transform;
    }

    public void Tick(Explode explode) {
        bool explosion = false;
        Collider[] cols = Physics.OverlapSphere(transform.position, 1.1f);
        foreach (var col in cols) if (col.gameObject.tag == "Boat") explosion = true;
        if (explosion) explode();
    }
}