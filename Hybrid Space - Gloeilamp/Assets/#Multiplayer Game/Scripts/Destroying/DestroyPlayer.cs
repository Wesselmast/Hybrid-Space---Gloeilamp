using UnityEngine;

public class DestroyPlayer : MonoBehaviour, IDestroyable {

    private Vector3 startPos;

    private void Start() { startPos = transform.position; }
    public void Destroy() { transform.position = startPos; }
}
