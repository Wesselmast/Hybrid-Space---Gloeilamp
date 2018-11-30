using UnityEngine;

public class DestroyNormal : MonoBehaviour, IDestroyable {
    public void Destroy() {
        Destroy(gameObject);
    }
}
