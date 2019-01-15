using UnityEngine;

public class IconFollow : MonoBehaviour {
    [SerializeField]
    private Transform iconPoint;
    [SerializeField]
    private float yPos = 50f;

    private Transform thisTransform;
    private Camera mapCam;

    private void Awake() {
        mapCam = GameObject.FindWithTag("MapCamera").GetComponent<Camera>();
    }

    private void Start() {
        thisTransform = transform;
    }

    private void FixedUpdate() {
        transform.position = new Vector3(iconPoint.position.x, yPos, iconPoint.position.z);
        transform.rotation = Quaternion.LookRotation(mapCam.transform.forward);
    }
}