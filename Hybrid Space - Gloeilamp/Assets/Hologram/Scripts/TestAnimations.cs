using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAnimations : MonoBehaviour {

    enum axis {
        x, y, z
    }

    [SerializeField]
    private float magnitude, limit;
    [SerializeField]
    private bool canMoveX, canMoveY, canMoveZ, canRotateX, canRotateY, canRotateZ;

    private Vector3 curPos, startPos;
    private Vector3 curRot, startRot;
    private bool moveInc, rotInc = false;

    private void Start() {
        startPos = gameObject.transform.position;
        startRot = gameObject.transform.eulerAngles;
    }

    private void FixedUpdate () {
        curPos = gameObject.transform.position;
        curRot = gameObject.transform.eulerAngles;
        if (WithinBounds(curPos, startPos, axis.x) && canMoveX) transform.Translate(Mathf.Sin(magnitude) * magnitude, 0, 0);
        if (WithinBounds(curPos, startPos, axis.y) && canMoveY) transform.Translate(0, Mathf.Sin(magnitude) * magnitude, 0);
        if (WithinBounds(curPos, startPos, axis.z) && canMoveZ) transform.Translate(0, 0, Mathf.Sin(Mathf.Pow(magnitude, 3)) * magnitude);
        if (WithinBounds(curRot, startRot, axis.x) && canRotateX) transform.Rotate(Mathf.Sin(magnitude) * magnitude, 0, 0);
        if (WithinBounds(curRot, startRot, axis.y) && canRotateY) transform.Rotate(0, Mathf.Sin(magnitude) * magnitude, 0);
        if (WithinBounds(curRot, startRot, axis.z) && canRotateZ) transform.Rotate(0, 0, Mathf.Sin(Mathf.Pow(magnitude, 3)) * magnitude);
    }

    bool WithinBounds(Vector3 curVec, Vector3 startVec, axis ax) {
        if (ax == axis.x && curVec.x <= -limit + startVec.x) return false;
        else if (ax == axis.y && curVec.y <= -limit + startVec.y) return false;
        else if (ax == axis.z && curVec.z <= -limit + startVec.z) return false;
        else return true;
    }
}
