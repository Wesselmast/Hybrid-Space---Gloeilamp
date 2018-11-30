using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BalloonBurner))]
public class BalloonParticles : MonoBehaviour {

    [SerializeField]
    private GameObject fire;

	void Start () {
        GetComponent<BalloonBurner>().OnBurn += Burn;
	}

    void Burn(bool burn) {
        fire.SetActive(burn);
    }
}
