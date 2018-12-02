using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BalloonInput))]
public class CameraSwitch : MonoBehaviour {
    [SerializeField]
    private Camera map;
    [SerializeField]
    private Camera balloon;

    void Start() {
        GetComponent<BalloonInput>().OnSwitch += Switch;
        balloon.enabled = true;
        map.enabled = false;
    }

    void Switch() {
        balloon.enabled = !balloon.enabled;
        map.enabled = !map.enabled;
    }
}
