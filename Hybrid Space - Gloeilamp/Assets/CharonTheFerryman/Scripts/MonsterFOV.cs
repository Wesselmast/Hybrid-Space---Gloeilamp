using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFOV : MonoBehaviour {

    [Range(0, 360)]
    public float viewAngle;
    public float viewRadius;

    [SerializeField]
    private LayerMask targetMask, obstacleMask;

    public List<Transform> visibleTargets = new List<Transform>();

    public void FindAllTargets() {
        visibleTargets.Clear();
        Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, targetMask);

        foreach (Collider target in targetsInViewRadius) {
            Vector3 dirToTarget = (target.transform.position - transform.position).normalized;
            if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2) {
                float dist = Vector3.Distance(transform.position, target.transform.position);
                //if the target is behind something, dont include it
                if (!Physics.Raycast(transform.position, dirToTarget, dist, obstacleMask)) {
                    visibleTargets.Add(target.transform);
                }
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) {
        if (!angleIsGlobal) angleInDegrees += transform.eulerAngles.y;
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}
