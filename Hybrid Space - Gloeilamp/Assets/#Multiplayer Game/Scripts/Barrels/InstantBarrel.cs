using UnityEngine;

public class InstantBarrel : IBarrel {
    private Transform transform;

    public InstantBarrel(Transform transform) {
        this.transform = transform;
    }

    public void Tick(Del explode) {
        bool explosion = false;
        Collider[] cols = Physics.OverlapSphere(transform.position, 0.1f);
        foreach (var col in cols) explosion = true;
        if (explosion) explode();
    }
}
