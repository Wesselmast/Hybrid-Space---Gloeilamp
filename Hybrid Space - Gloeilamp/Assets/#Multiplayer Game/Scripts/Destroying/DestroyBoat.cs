using UnityEngine;
[RequireComponent(typeof(BoatEngine))]
public class DestroyBoat : MonoBehaviour, IDestroyable {
    [SerializeField]
    private float damage;

    public void Destroy() {
        HealthManager.RemoveHealth(damage);
    }
}