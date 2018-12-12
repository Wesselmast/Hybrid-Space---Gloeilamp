﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanExplode : MonoBehaviour {
    [SerializeField]
    private LayerMask playerLayer;
    [SerializeField]
    private float startExplodeTimer;
    public float radius;
    [SerializeField]
    private GameObject explosionParticle;

    private GameObject explosion;
    private bool hasExploded = false;

    private float explodeTimer;

    private void Start() {
        explodeTimer = startExplodeTimer;
    }

    private void Update() {
        if (explodeTimer <= 0 && !hasExploded) {
            Explode();
            hasExploded = true;
        }
        else explodeTimer -= Time.deltaTime;
    }

    private void Explode() {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius, playerLayer);
        foreach (Collider col in colliders) col.GetComponent<IDestroyable>().Destroy();

        explosion = (GameObject)Instantiate(explosionParticle, transform.position, Quaternion.identity);
        Destroy(explosion, 1.0F);

        Destroy(gameObject);
    }
}
