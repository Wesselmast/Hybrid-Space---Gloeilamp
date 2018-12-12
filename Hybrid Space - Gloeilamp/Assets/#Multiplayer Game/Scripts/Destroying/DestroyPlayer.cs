using UnityEngine;
using System.Collections;

public class DestroyPlayer : MonoBehaviour, IDestroyable {

    public float stunDuration = 3f;
    BoatEngine boat;

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
