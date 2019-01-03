using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour {

    [SerializeField]
    private Transform steerPos;

	// Update is called once per frame
	void LateUpdate () {
        transform.position = steerPos.transform.position;
        transform.rotation = steerPos.transform.rotation;
	}
}
