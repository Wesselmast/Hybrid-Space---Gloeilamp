using UnityEngine;

public class Spawner : MonoBehaviour {

    [SerializeField]
    private GameObject[] spawnableObjects;

    private Transform[] spawnPoints;

    private void Awake() {
        spawnPoints = GetComponentsInChildren<Transform>();
    }

    private void Start () {
        for (int i = 0; i < spawnPoints.Length; i++) {
            Instantiate(spawnableObjects[Random.Range(0, spawnableObjects.Length)], spawnPoints[i].position, Quaternion.identity);
        }
	}
}