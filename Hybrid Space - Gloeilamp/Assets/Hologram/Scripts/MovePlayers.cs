using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayers : MonoBehaviour {

    [SerializeField]
    private float speed, turnSpeed;
    [SerializeField]
    private KeyCode left, right, bomb;
    [SerializeField]
    private GameObject bombObj;
    [SerializeField]
    private float startBombCooldown;

    private bool rotateLeft, rotateRight = false;
    private bool hasCollided;
    private float bombCooldown = 0.0f;
    private float startYPos;

    private void OnCollisionEnter(Collision other) {
        if (!hasCollided && other.transform.tag == "ground") {
            hasCollided = true;
            startYPos = transform.position.y;
            StartCoroutine(Run());
        }
    }

    IEnumerator Run() {
        hasCollided = true;
        while (true) {
            transform.Translate(0, 0, speed * Time.fixedDeltaTime);
            if(Input.GetKey(right)) gameObject.transform.localEulerAngles += new Vector3(0, -turnSpeed, 0);
            if(Input.GetKey(left)) gameObject.transform.localEulerAngles += new Vector3(0, turnSpeed, 0);
            BombSpawning();
            if (gameObject.transform.position.y <= startYPos - 100) Destroy(gameObject);
            yield return null;
        }
    }

    void BombSpawning() {
        if (bombCooldown <= 0.0f && Input.GetKeyDown(bomb)) {
            GameObject b = Instantiate(bombObj, gameObject.transform.position, Quaternion.identity);
            b.transform.parent = transform.parent;
            bombCooldown = startBombCooldown;
        }
        else bombCooldown -= Time.fixedDeltaTime;
    }
}
