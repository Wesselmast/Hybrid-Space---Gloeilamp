using UnityEngine;

public class Powerup : MonoBehaviour {
    private enum Player {
        Boat, Balloon
    }

    [SerializeField]
    private ScriptableBuff scriptableBuff;
    [SerializeField]
    private Player player;

    private float startRot;

    private void Start() {
        startRot = transform.eulerAngles.y;
    }

    private void FixedUpdate() {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, 
                                            startRot += Time.deltaTime * 5, 
                                            transform.eulerAngles.z);
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == player.ToString()) {
            try { other.GetComponent<Buffable>().AddBuff(scriptableBuff); }
            catch { Debug.LogError("Buffable component not found!"); }
            Destroy(gameObject);
        }
    }
}
