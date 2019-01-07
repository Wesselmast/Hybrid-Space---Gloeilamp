using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPosition : MonoBehaviour {

    [SerializeField]
    private Transform objPos;

	// Update is called once per frame
	void FixedUpdate () {
        transform.position = objPos.transform.position;
        transform.eulerAngles = new Vector3(objPos.eulerAngles.x, transform.eulerAngles.y, objPos.eulerAngles.z);
    }
}
