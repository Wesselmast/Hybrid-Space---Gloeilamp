using UnityEngine;

public class RandomizeHeight : MonoBehaviour {
    [SerializeField]
    private float min, max;

    private void Start() {
        transform.position = new Vector3(transform.position.x, Random.Range(min, max), transform.position.z);
    }
}
