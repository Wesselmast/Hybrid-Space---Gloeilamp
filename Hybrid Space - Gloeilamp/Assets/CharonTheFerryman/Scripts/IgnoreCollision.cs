using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {

    [SerializeField]
    private Transform Torch, Barrel;

    void Start() {
        Physics.IgnoreCollision(Torch.GetComponent<Collider>(), GetComponent<Collider>());
        Physics.IgnoreCollision(Barrel.GetComponent<Collider>(), GetComponent<Collider>());
    }
}
