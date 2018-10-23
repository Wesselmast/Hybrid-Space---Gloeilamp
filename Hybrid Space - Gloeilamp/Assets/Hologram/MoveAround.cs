using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAround : MonoBehaviour {

    [SerializeField]
    private float magnitude, limit;

    private Vector3 curPos, startPos;
    private Vector3 curRot, startRot;
    private bool moveInc, rotInc = false;

    private void Start() {
        startPos = gameObject.transform.position;
        startRot = gameObject.transform.eulerAngles;
    }

    void Update () {
        curPos = gameObject.transform.position;
        if (curPos.x <= -limit + startPos.x && curPos.y <= -limit + startPos.y && curPos.z <= -limit + startPos.z) moveInc = true;
        if (curPos.x >= limit + startPos.x && curPos.y >= limit + startPos.y && curPos.z >= limit + startPos.z) moveInc = false;
        if (curRot.x <= -limit + curRot.x && curRot.y <= -limit + curRot.y && curRot.z <= -limit + curRot.z) rotInc = true;
        if (curRot.x >= limit + curRot.x && curPos.y >= limit + curRot.y && curRot.z >= limit + curRot.z) rotInc = false;
    }

    private void FixedUpdate() {
        if (moveInc) transform.Translate(Mathf.Sin(magnitude), Mathf.Sin(magnitude), Mathf.Sin(Mathf.Pow(magnitude, 3)));
        else transform.Translate(Mathf.Sin(-magnitude), Mathf.Sin(-magnitude), Mathf.Sin(-Mathf.Pow(magnitude, 3)));
        if (rotInc) transform.Rotate(Mathf.Sin(magnitude), Mathf.Sin(magnitude), Mathf.Sin(Mathf.Pow(magnitude, 3)));
        else transform.Rotate(Mathf.Sin(-magnitude), Mathf.Sin(-magnitude), Mathf.Sin(-Mathf.Pow(magnitude, 3)));
    }
}
