using System;
using UnityEngine;

public class BalloonInput : MonoBehaviour {
    [SerializeField]
    private ArduinoCom com;

    public bool GoingUp { get; private set; }
    public event Action OnRotateLeftSoft = delegate { };
    public event Action OnRotateRightSoft = delegate { };
    public event Action OnRotateLeftHard = delegate { };
    public event Action OnRotateRightHard = delegate { };
    public event Action OnDrop = delegate { };
    public event Action OnSwitch = delegate { };

    void Update () {
        GoingUp = com.Up || Input.GetKey(KeyCode.Space) ? true : false;
        if (com.SoftLeft || Input.GetKey(KeyCode.A)) OnRotateLeftSoft();
        if (com.SoftRight || Input.GetKey(KeyCode.D)) OnRotateRightSoft();
        if (com.DropItems || Input.GetKeyDown(KeyCode.B)) OnDrop();
        if (com.HardLeft) OnRotateLeftHard();
        if (com.HardRight) OnRotateRightHard();
	}
}