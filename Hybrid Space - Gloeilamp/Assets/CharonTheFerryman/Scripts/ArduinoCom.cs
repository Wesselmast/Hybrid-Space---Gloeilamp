using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoCom : MonoBehaviour {

    [HideInInspector]
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public bool left, right, up, barrels = false;
=======
    public bool left, right, lantern, up = false;
>>>>>>> Stashed changes
=======
    public bool left, right, lantern, up = false;
>>>>>>> Stashed changes

    //this stuff has to be hardcoded, so if you get weird errors check this out
    private SerialPort port = new SerialPort("COM7", 9600);
    private int input;

	void Start () {
        try { port.Open(); }
        catch (System.Exception e) { Debug.Log("System Error: " + e.ToString()); }
    }
	
	void Update () {
        if(int.TryParse(port.ReadLine(), out input)) {
            Debug.Log("Input: " + input);
            if (input == 1) left = true;
            else if (input == 2) right = true;
<<<<<<< Updated upstream
<<<<<<< Updated upstream
            else if (input == 3) up = true;
            else if (input == 4) barrels = true;
            else { left = false; right = false; barrels = false; up = false; }
=======
            else if (input == 3) lantern = true;
            else if (input == 4) up = true;
            else { left = false; right = false; lantern = false; up = false; }
>>>>>>> Stashed changes
=======
            else if (input == 3) lantern = true;
            else if (input == 4) up = true;
            else { left = false; right = false; lantern = false; up = false; }
>>>>>>> Stashed changes
        }
	}
}
