using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour {
    [SerializeField]
    private Camera map, perspective;
 
    void Start() {
        perspective.enabled = true;
        map.enabled = false;
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            perspective.enabled = !perspective.enabled;
            map.enabled = !map.enabled;
        }
    }
}
