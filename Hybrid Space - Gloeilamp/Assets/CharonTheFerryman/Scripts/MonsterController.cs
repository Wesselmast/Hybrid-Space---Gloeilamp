using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {
    [SerializeField]
    private Transform[] spawnpoints;
    [SerializeField]
    private Transform lookTarget;
    [SerializeField]
    private float pullForce = 0.75f;

    [Header("Timing")]
    [SerializeField]
    private float startSuckDuration;
    [SerializeField]
    private float switchTime = 5.0f;

    private MonsterFOV fov;
    private float suckDuration;


    private void Start() {
        fov = GetComponent<MonsterFOV>();
        StartCoroutine(SwitchPosition());
    }

    void FixedUpdate() {
        transform.LookAt(lookTarget);
    }

    void SuckMove() {
        fov.FindAllTargets();
        if (fov.visibleTargets.Count != 0) {
            foreach (Transform target in fov.visibleTargets) {
                float dist = Vector3.Distance(transform.position, target.position);
                Rigidbody rb = target.GetComponent<Rigidbody>();
                rb.AddForce(Vector3.Normalize(transform.position - target.position)
                            * (1 / dist * dist) * pullForce, ForceMode.Acceleration);
                if (suckDuration <= 0.25) rb.velocity = Vector3.zero;
            }
        }
    }

    IEnumerator SwitchPosition() {
        suckDuration = startSuckDuration;
        transform.position = spawnpoints[Random.Range(0, spawnpoints.Length)].position;
        while (suckDuration > 0) {
            SuckMove();
            suckDuration -= Time.smoothDeltaTime;
            yield return null;
        }
        if (fov.visibleTargets.Count != 0) {
            foreach (Transform target in fov.visibleTargets) {
                target.GetComponent<Rigidbody>().velocity = Vector3.zero; 
            }
        }
        yield return new WaitForSeconds(switchTime);
        //Remember to add an if statement to check if it's not dead
        StartCoroutine(SwitchPosition());
    }
}
