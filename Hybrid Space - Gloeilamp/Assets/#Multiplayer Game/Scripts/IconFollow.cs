<<<<<<< HEAD
﻿using UnityEngine;

public class IconFollow : MonoBehaviour {
    [SerializeField]
    private Transform iconPoint;
    [SerializeField]
    private float yPos = 50f;

    private Transform thisTransform;
    Camera mapCam;

    private void Start() {
        thisTransform = transform;
        mapCam = GameObject.FindWithTag("MapCamera").GetComponent<Camera>();
    }

    private void FixedUpdate() {
        transform.position = new Vector3(iconPoint.position.x, yPos, iconPoint.position.z);
        transform.rotation = Quaternion.LookRotation(mapCam.transform.forward);
    }
=======
﻿using UnityEngine;

public class IconFollow : MonoBehaviour {
    [SerializeField]
    private Transform iconPoint;
    [SerializeField]
    private float yPos = 50f;

    private Transform thisTransform;
    Camera mapCam;

    private void Start() {
        thisTransform = transform;
        mapCam = GameObject.FindWithTag("MapCamera").GetComponent<Camera>();
    }

    private void FixedUpdate() {
        transform.position = new Vector3(iconPoint.position.x, yPos, iconPoint.position.z);
        transform.rotation = Quaternion.LookRotation(mapCam.transform.forward);
    }
>>>>>>> master
}