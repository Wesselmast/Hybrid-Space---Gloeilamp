using UnityEditor;
using UnityEngine;

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
