using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(IDestroyable))]
public class CanPowerUp : MonoBehaviour {
    [SerializeField]
    private Transform barrelDropSpot;
    [SerializeField]
    private GameObject barrelPrefab;
    [SerializeField]
    private LayerMask playerLayer;
    [SerializeField]
    private PowerupType type;
    [SerializeField]
    private PlayerType player;

    private enum PlayerType {
        Boat,
        Balloon
    }

    private enum PowerupType {
        BarrelBarrage,
        Shield,
        Speed
    }

    private IPowerup powerup;
    private Del del;

	private void Awake () {
        del = InstantiateBarrel;
        switch (type) {
            case PowerupType.BarrelBarrage:
                powerup = new BarrelBarrage(GetComponent<IDestroyable>(), del);
                break;
            case PowerupType.Shield:
                powerup = new Shield(GetComponent<IDestroyable>());
                break;
            case PowerupType.Speed:
                powerup = new Speed(GetComponent<IDestroyable>());
                break;
        }
    }

    private void Update () {
        Collider[] cols = Physics.OverlapSphere(transform.position, 10f, playerLayer);
        foreach (var col in cols) {
            if (col.gameObject.tag == player.ToString()) powerup.PowerUp();
        }
	}

    private void InstantiateBarrel() {
        StartCoroutine(Spawn());

        GetComponent<IDestroyable>().Destroy();
    }

    private IEnumerator Spawn() {
        for (int i = 0; i < 10; i++) {
            Instantiate(barrelPrefab, barrelDropSpot.position, Quaternion.identity);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
