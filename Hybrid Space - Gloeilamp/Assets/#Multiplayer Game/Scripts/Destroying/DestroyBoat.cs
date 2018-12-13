using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoatEngine))]
public class DestroyBoat : MonoBehaviour, IDestroyable {
    [SerializeField]
    private float stunDuration = 3f;

    private BoatEngine boat;

    private void Start() {
        boat = GetComponent<BoatEngine>();
    }

    public void Destroy() {
        StartCoroutine(Stun());
    }

    private IEnumerator Stun() {
        boat.enabled = false;
        yield return new WaitForSeconds(stunDuration);
        boat.enabled = true;
    }
}
