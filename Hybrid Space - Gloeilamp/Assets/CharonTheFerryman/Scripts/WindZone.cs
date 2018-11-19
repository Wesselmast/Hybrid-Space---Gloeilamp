using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZone : MonoBehaviour {

    private Vector2[] compass = {
        new Vector2(-1, -1),
        new Vector2(-1, 0),
        new Vector2(-1, 1),
        new Vector2(0, -1),
        new Vector2(0, 0),
        new Vector2(0, 1),
        new Vector2(1, -1),
        new Vector2(1, 0),
        new Vector2(1, 1),
    };

    [SerializeField]
    private float strenght, startTimer;

    private int dirIndex;
    private Vector3 direction;
    private float timer;

    private void Start() {
        direction.y = 0;
        dirIndex = Random.Range(0, compass.Length);
    }

    private void FixedUpdate() {
        if (timer <= 0) {
            int rand = Random.Range(0, 2);
            if (dirIndex >= compass.Length - rand - 1) dirIndex = 0;
            direction.x = compass[dirIndex += rand].x;
            direction.z = compass[dirIndex += rand].y;
            timer = startTimer;
        }
        else timer -= Time.deltaTime;
    }

    private void OnTriggerStay(Collider other) {
        var rb = other.GetComponent<Rigidbody>();
        if (rb != null) {
            rb.AddForce(direction * strenght, ForceMode.Force);
        }
    }
}
