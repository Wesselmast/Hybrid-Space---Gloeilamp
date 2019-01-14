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

    private SerialPort port;
    private const int baudRate = 9600;
    private int input;

	private void Awake () {
        string portName = "COM11";
        string[] portNums = System.Text.RegularExpressions.Regex.Split(portName, @"\D+");
        port = (int.Parse(portNums[1]) >= 10) ? new SerialPort("\\\\.\\" + portName, baudRate) :
                                                  new SerialPort(portName, baudRate);
        port.ReadTimeout = 50;
        try { port.Open(); }
        catch { gameObject.SetActive(false); Debug.LogWarning("Couldn't open serial port " + portName + "!"); }
    }
	
	private void Update () {
        port.BaseStream.Flush();
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
        }
	}
}