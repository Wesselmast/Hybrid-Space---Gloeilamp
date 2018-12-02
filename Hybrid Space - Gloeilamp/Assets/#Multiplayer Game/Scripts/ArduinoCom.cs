using UnityEngine;
using System.IO.Ports;

public class ArduinoCom : MonoBehaviour {

    [HideInInspector]
    public bool left, right, up, dropItems, switchCameras;

    private SerialPort port = new SerialPort("COM7", 9600);
    private int input;

	void Awake () {
        try { port.Open(); }
        catch (System.Exception) { gameObject.SetActive(false); }
    }
	
	void Update () {
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
