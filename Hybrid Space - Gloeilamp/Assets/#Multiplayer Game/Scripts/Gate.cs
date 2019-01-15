using UnityEngine;

public class Gate : MonoBehaviour {

    [SerializeField]
    private Animator anim;

    private void Start() {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag == "Boat") {
            anim.Play("GateOpen");
            Destroy(gameObject);
        }
    }
}
