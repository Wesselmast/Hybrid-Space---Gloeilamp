using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPlayerPosition : MonoBehaviour {

    [SerializeField]
    private Transform playerPos;

    // Update is called once per frame
    void FixedUpdate() {
        transform.position = playerPos.transform.position;
        transform.eulerAngles = new Vector3(playerPos.eulerAngles.x, playerPos.eulerAngles.y, 0);
    }
}
