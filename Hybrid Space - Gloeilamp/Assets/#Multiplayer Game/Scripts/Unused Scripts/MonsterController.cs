using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour {

    [Header("Monster Stats")]
    [SerializeField]
    private float damagePerBarrel;

    [Header("Attack & Switching")]
    [SerializeField]
    private float startSuckDuration;
    [SerializeField]
    private float switchTime = 5.0f;
    [SerializeField]
    private float pullForce = 0.75f;

    [SerializeField]
    private Transform[] spawnpoints;
    [SerializeField]
    private Transform lookTarget;

    private MonsterFOV fov;
    private float suckDuration;
    private float health = 100;

    private void Start() {
        fov = GetComponent<MonsterFOV>();
        StartCoroutine(SwitchPosition());
    }

    void FixedUpdate() {
        transform.LookAt(lookTarget);
        if (health <= 0) StartCoroutine(Die());
    }

    void SuckMove() {
        fov.FindAllTargets();
        if (fov.visibleTargets.Count != 0) {
            foreach (Transform target in fov.visibleTargets) {
                float dist = Vector3.Distance(transform.position, target.position);
                Rigidbody rb = target.GetComponent<Rigidbody>();
                rb.AddForce(Vector3.Normalize(transform.position - target.position)
                            * (1 / dist * dist) * pullForce, ForceMode.Acceleration);
                if (suckDuration <= 0.05) rb.velocity = Vector3.zero;
            }
        }
    }

    IEnumerator Die() {
        //LATER ADD AN ANIMATION AND STUFF
        float deathAnimationLength = 0;
        yield return new WaitForSeconds(deathAnimationLength);
        Destroy(gameObject); //maybe just leave a corpse but this is fine for now
    }

    IEnumerator SwitchPosition() {
        suckDuration = startSuckDuration;
        transform.position = spawnpoints[Random.Range(0, spawnpoints.Length)].position;
        while (suckDuration > 0) {
            SuckMove();
            suckDuration -= Time.fixedDeltaTime;
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

    private void OnCollisionEnter(Collision collision) {
        if (collision.transform.tag == "Barrel") {
            //LATER HAVE 'BARREL LIT' AS A REQUIREMENT
            health -= damagePerBarrel;
            Destroy(collision.gameObject);
        }
    }
}
