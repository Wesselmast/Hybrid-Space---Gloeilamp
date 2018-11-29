using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgniteBarrel : MonoBehaviour {

    [SerializeField]
    private Transform ignitePart;

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Torch") {
            ignitePart.GetChild(0).gameObject.SetActive(true);
            StartCoroutine(Explode(5));
            // TODO: Explode particles, take damage
        }
    }

    private IEnumerator Explode(float waitTime) {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
