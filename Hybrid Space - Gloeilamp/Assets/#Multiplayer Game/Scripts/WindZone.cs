using UnityEngine;

[RequireComponent(typeof(BalloonEngine))]
[RequireComponent(typeof(Rigidbody))]
public class WindZone : MonoBehaviour {
    [SerializeField]
    private float movementScale;
    [SerializeField]
    private Collider windZone;

    private FMODCom com;

    private void Awake() {
        com = new FMODCom("Windzone");
    }

    private void OnTriggerEnter(Collider other) {
        if (other == windZone) {
            GetComponent<BalloonEngine>().MovementSpeed *= movementScale;
            com.SetParameter("InWindZone", 1f);
            com.Play3D(transform, GetComponent<Rigidbody>());
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other == windZone) {
            GetComponent<BalloonEngine>().MovementSpeed /= movementScale;
            com.SetParameter("InWindZone", 0f);
        }
    }
}