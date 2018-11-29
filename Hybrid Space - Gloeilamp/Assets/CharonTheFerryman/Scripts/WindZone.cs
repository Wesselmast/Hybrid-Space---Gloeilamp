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
    private float strenght, minWindValue, maxWindValue;
    [SerializeField]
    private string[] acceptedTags;

    private int dirIndex;
    private Vector3 direction;
    private float timer;

    private void Start() {
        direction.y = 0;
        dirIndex = Random.Range(0, compass.Length);
    }

    private void FixedUpdate() {
        if (timer <= 0) {
            if (dirIndex >= compass.Length) dirIndex = 0;
            direction.x = compass[dirIndex].x;
            direction.z = compass[dirIndex++].y;
            timer = Random.Range(minWindValue, maxWindValue);
        }
        else timer -= Time.deltaTime;
    }

    private void OnTriggerStay(Collider other) {
        foreach (string tag in acceptedTags) {
            if (other.tag == tag) {
                other.transform.position += direction * Time.fixedDeltaTime;
            }
        }
    }
}
