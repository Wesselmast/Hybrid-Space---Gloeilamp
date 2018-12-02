using System;
using UnityEngine;

public class BalloonInput : MonoBehaviour {

    [SerializeField]
    private ArduinoCom com;

    public bool GoingUp { get; private set; }

    public event Action OnRotateLeft = delegate { };
    public event Action OnRotateRight = delegate { };
    public event Action OnDrop = delegate { };
    public event Action OnSwitch = delegate { };

    void Update () {
        if (com.up || Input.GetKey(KeyCode.Space)) GoingUp = true;
        else GoingUp = false;
        if (com.left || Input.GetKey(KeyCode.A)) OnRotateLeft();
        if (com.right || Input.GetKey(KeyCode.D)) OnRotateRight();
        if (com.dropItems || Input.GetKeyDown(KeyCode.B)) OnDrop();
        if (com.switchCameras || Input.GetKeyDown(KeyCode.M)) OnSwitch();
	}
}
