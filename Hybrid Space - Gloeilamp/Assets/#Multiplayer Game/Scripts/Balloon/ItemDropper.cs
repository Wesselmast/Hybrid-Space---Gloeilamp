using UnityEngine;

[RequireComponent(typeof(BalloonInput))]
public class ItemDropper : MonoBehaviour {

    public Animation barrelReleaseAnim;
    [SerializeField]
    private Rigidbody item;
    [SerializeField]
    private Transform dropSpot;
    [SerializeField]
    private float startDropTimer = 3.0f;

    private float dropTimer;

	private void Awake() {
        GetComponent<BalloonInput>().OnDrop += Drop;
    }

    private void FixedUpdate() {
        dropTimer -= Time.fixedDeltaTime;
    }

    private void Drop() {
        if (dropTimer <= 0) {
            barrelReleaseAnim.Play();
            InstantiateBarrel();
            dropTimer = startDropTimer;
        }
    }

    public void InstantiateBarrel() {
        Instantiate(item, dropSpot.position, Quaternion.identity);
    }
}
