using UnityEngine;
using System.IO.Ports;

public class ArduinoCom : MonoBehaviour {
    private bool left, right, up, dropItems, switchCameras;
    public bool Left { get { return left; } }
    public bool Right { get { return right; } }
    public bool Up { get { return up; } }
    public bool DropItems { get { return dropItems; } }
    public bool SwitchCameras { get { return switchCameras; } }

    private SerialPort port = new SerialPort("COM7", 9600);
    private int input;

	private void Awake () {
        try { port.Open(); }
        catch (System.Exception) { gameObject.SetActive(false); }
    }
	
	private void Update () {
        if(int.TryParse(port.ReadLine(), out input)) {
            Debug.Log("Input: " + input);
            if (input == 1) left = true;
            else if (input == 2) right = true;
            else if (input == 3) up = true;
            else if (input == 4) dropItems = true;
            else if (input == 5) switchCameras = true;
            else { left = false; right = false; dropItems = false; up = false; switchCameras = false; }
        }
	}
}
