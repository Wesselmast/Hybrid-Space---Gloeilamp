using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    private Transform player;
    private Vector3 targetPos, thisPos;

    void Start() {
        targetPos = player.position;
        thisPos = transform.position;
    }

    private void FixedUpdate() {
        transform.position = thisPos + player.position - targetPos;
    }
}