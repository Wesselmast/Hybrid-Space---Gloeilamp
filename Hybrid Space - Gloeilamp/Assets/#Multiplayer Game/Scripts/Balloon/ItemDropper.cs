using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BalloonInput))]
public class ItemDropper : MonoBehaviour {
    [SerializeField]
    private Rigidbody item;
    [SerializeField]
    private Transform dropSpot;
    [SerializeField]
    private float startDropTimer = 3.0f;

    private float dropTimer;

	void Awake() { GetComponent<BalloonInput>().OnDrop += Drop; }
    private void FixedUpdate() { dropTimer -= Time.fixedDeltaTime; }

    void Drop() {
        if (dropTimer <= 0) {
            Instantiate(item, dropSpot.position, Quaternion.identity);
            dropTimer = startDropTimer;
        }
    }
	
}
