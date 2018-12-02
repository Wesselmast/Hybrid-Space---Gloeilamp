using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {

    [SerializeField]
    private List<Transform> ignoreObject;

    void Start() {
        for (int i = 0; i < ignoreObject.Count; i++) {
            Physics.IgnoreCollision(ignoreObject[i].GetComponent<Collider>(), GetComponent<Collider>());
        }
    }
}
