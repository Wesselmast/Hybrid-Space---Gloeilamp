using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float smoothSpeed;
    [SerializeField]
    private Vector3 offset;

    /*
    private void FixedUpdate() {
        transform.position = Vector3.Lerp(transform.position, target.position + offset, smoothSpeed);
        transform.eulerAngles = Vector3.Lerp(transform.position, target.eulerAngles, smoothSpeed);
    }
    */

    private void LateUpdate() {
        Vector3 position = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, position, smoothSpeed);
        transform.position = smoothedPosition;
        transform.LookAt(target);
    }
}