using UnityEngine;

[RequireComponent(typeof(BalloonEngine))]
public class WindZone : MonoBehaviour {
    [SerializeField]
    private float movementScale;
    [SerializeField]
    private Collider windZone;

    private BalloonEngine engine;

    private void Awake() {
        engine = GetComponent<BalloonEngine>();        
    }

    private void OnTriggerEnter(Collider other) {
        if (other == windZone) {
            engine.MovementSpeed *= movementScale;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other == windZone) {
            engine.MovementSpeed /= movementScale;
        }
    }
}