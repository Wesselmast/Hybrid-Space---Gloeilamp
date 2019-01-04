using UnityEngine;

public class Powerup : MonoBehaviour {
    private enum Player {
        Boat, Balloon
    }

    [SerializeField]
    private ScriptableBuff scriptableBuff;
    [SerializeField]
    private Player player;

    private void OnTriggerEnter(Collider other) {
        if (other.tag == player.ToString()) {
            try { other.GetComponent<Buffable>().AddBuff(scriptableBuff); }
            catch { Debug.LogError("Buffable component not found!"); }
            Destroy(gameObject);
        }
    }
}
