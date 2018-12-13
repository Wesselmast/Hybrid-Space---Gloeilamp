using UnityEngine;

public class CameraFollow : MonoBehaviour {
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float damping;
    [SerializeField]
    private Vector3 offset;

    private Transform thisTransform;

    private void Start() {
        thisTransform = transform;
    }

    private void FixedUpdate() {
        transform.position = target.position + offset;
        Quaternion rotation = Quaternion.LookRotation(target.position - thisTransform.position);
        thisTransform.rotation = Quaternion.Slerp(thisTransform.rotation, rotation, Time.deltaTime * damping);
    }
}