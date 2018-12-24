using UnityEngine;
[RequireComponent(typeof(BoatEngine))]
public class DestroyBoat : MonoBehaviour, IDestroyable {
    [SerializeField]
    private int reducedTime;

    public void Destroy() {
        CustomTimer.TotalSeconds -= reducedTime;
    }
}
