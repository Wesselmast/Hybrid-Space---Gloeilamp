using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CanExplode))]
public class FOVEditor : Editor {

    private void OnSceneGUI() {
        CanExplode fov = (CanExplode)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.radius);
    }
}
