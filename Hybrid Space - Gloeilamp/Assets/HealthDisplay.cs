using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

    [SerializeField]
    private RawImage boatFront, boatBack, boatSail;
    [SerializeField]
    private Texture boatFrontGrey, boatBackGrey, boatSailGrey;
    [SerializeField]
    private GameObject leak, waterClipping, mast;

    private void Update() {
        if (HealthManager.GetCurrentHealth() == 1) {
            boatSail.GetComponent<RawImage>().texture = boatSailGrey;
            mast.SetActive(false);
        }

        else if (HealthManager.GetCurrentHealth() == 0) {
            boatFront.GetComponent<RawImage>().texture = boatFrontGrey;
            leak.SetActive(true);
            waterClipping.SetActive(false);
        }

        if (HealthManager.GetCurrentHealth() < 0) {
            boatBack.GetComponent<RawImage>().texture = boatBackGrey;
        }
    }
}
