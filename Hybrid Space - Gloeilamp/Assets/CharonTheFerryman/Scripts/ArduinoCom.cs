using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoCom : MonoBehaviour {

    [HideInInspector]
    public bool left, right = false;

    //this stuff has to be hardcoded, so if you get weird errors check this out
    private SerialPort port = new SerialPort("COM7", 9600);
    private int input;

	void Start () {
        try { port.Open(); }
        catch (System.Exception e) { }
    }
	
	void Update () {
        if(int.TryParse(port.ReadLine(), out input)) {
            Debug.Log("Input: " + input);   
            if (input == 1) left = true;
            else if (input == 2) right = true;
            else { left = false; right = false; }
        }
	}
}
