using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SoundOnCollision : MonoBehaviour {
    [SerializeField]
    private string eventName;
    [SerializeField]
    private string collisionTag = "Map";

    private FMODCom com;

    private void Awake() {
        com = new FMODCom(eventName);
    }

    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == collisionTag) {
            com.Play3D(transform, GetComponent<Rigidbody>());
        }
    }

}
