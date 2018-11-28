using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    private Transform target;
    private Vector3 targetPos, targetRot, thisPos, thisRot;

    void Start() {
        targetPos = target.position;
        targetRot = target.eulerAngles;
        thisPos = transform.position;
        thisRot = transform.eulerAngles;
    }

    private void FixedUpdate() {
        transform.position = thisPos + target.position - targetPos;
        transform.eulerAngles = thisRot + target.eulerAngles - targetRot;
    }
}