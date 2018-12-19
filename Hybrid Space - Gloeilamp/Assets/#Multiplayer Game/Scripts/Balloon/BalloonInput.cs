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
        if (com.Up || Input.GetKey(KeyCode.Space)) GoingUp = true;
        else GoingUp = false;
        if (com.Left || Input.GetKey(KeyCode.A)) OnRotateLeft();
        if (com.Right || Input.GetKey(KeyCode.D)) OnRotateRight();
        if (com.DropItems || Input.GetKeyDown(KeyCode.B)) OnDrop();
        if (com.SwitchCameras || Input.GetKeyDown(KeyCode.M)) OnSwitch();
	}
}
