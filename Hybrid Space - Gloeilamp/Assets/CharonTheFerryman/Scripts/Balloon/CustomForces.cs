using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CustomForces : MonoBehaviour {
    public bool selfRighting = true;
    public float selfRightingOffset = 1.0f;
    public bool customGravity = true;
    public float balloonGravity = 0.1f;

    private Rigidbody rb;

    private void Awake() { rb = GetComponent<Rigidbody>(); }

    void Update () {
        if (selfRighting) {
            rb.AddForceAtPosition(Vector3.down, transform.TransformPoint(Vector3.up * -selfRightingOffset));
        }
        if (customGravity) {
            rb.AddForce(Vector3.down * balloonGravity, ForceMode.Acceleration);
        }
    }
}

[CustomEditor(typeof(CustomForces))]
public class CustomForcesEditor : Editor {
    public override void OnInspectorGUI() {
        CustomForces customForces = target as CustomForces;
        customForces.selfRighting = GUILayout.Toggle(customForces.selfRighting, "Self-Righting");
        customForces.customGravity = GUILayout.Toggle(customForces.customGravity, "Custom Gravity");
        if (customForces.selfRighting) {
            customForces.selfRightingOffset = 
                EditorGUILayout.Slider("Self-Righting Offset", customForces.selfRightingOffset, 0, 10);
        }
        if (customForces.customGravity) {
            customForces.balloonGravity = 
                EditorGUILayout.Slider("Balloon Gravity", customForces.balloonGravity, 0, 4);
        }
    }
}
