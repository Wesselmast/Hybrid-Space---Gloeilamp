using UnityEngine;

public class SetPlayerPosition : MonoBehaviour {

    [SerializeField]
    private Transform playerPos;

    private void FixedUpdate() {
        transform.position = playerPos.transform.position;
        transform.eulerAngles = new Vector3(playerPos.eulerAngles.x, playerPos.eulerAngles.y, 0);
    }
}