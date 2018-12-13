using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableVR : MonoBehaviour {

    public bool enableVR = true;

    [SerializeField]
    private GameObject VRCamera, nonVRCamera;

	// Use this for initialization
	void Start () {
		if (enableVR) {
            VRCamera.SetActive(true);
            nonVRCamera.SetActive(false);
        } else {
            VRCamera.SetActive(false);
            nonVRCamera.SetActive(true);
        }
	}
}
