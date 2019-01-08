using UnityEngine;
using System.IO.Ports;

public class ArduinoCom : MonoBehaviour {
    private bool softLeft, softRight, hardLeft, hardRight, up, dropItems;
    public bool SoftLeft { get { return softLeft; } }
    public bool SoftRight { get { return softRight; } }
    public bool HardLeft { get { return hardLeft; } }
    public bool HardRight { get { return hardRight; } }
    public bool Up { get { return up; } }
    public bool DropItems { get { return dropItems; } }

    private SerialPort port = new SerialPort("COM9", 9600);
    private int input;

	private void Awake () {
        try { port.Open(); }
        catch { gameObject.SetActive(false); }
    }
	
	private void Update () {
        if(int.TryParse(port.ReadLine(), out input)) {
            if (input == 1) softLeft = true;
            else if (input == 2) softRight = true;
            else if (input == 3) hardLeft = true;
            else if (input == 4) hardRight = true;
            else if (input == 5) up = true;
            else if (input == 6) dropItems = true;
            else {
                softLeft = false;
                softRight = false;
                hardLeft = false;
                hardRight = false;
                dropItems = false;
                up = false;
            }
            port.ReadTimeout = 50;
        }
	}
}