using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float timeBetweenShots = 0.5f;

    bool canShoot = true;

    void Update() {

        if (Input.GetMouseButtonDown(0) && canShoot == true) {
            StartCoroutine(Shoot());
        }

    }

    private IEnumerator Shoot() {
        canShoot = false;
        if (this.ammoSlot.GetCurrentAmmo() > 0) {
            PlayMuzzleFlash();
            ProcessRaycast();
            this.ammoSlot.ReduceCurrentAmmo();
        }
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
    }

    private void PlayMuzzleFlash() {
        this.muzzleFlash.Play();
    }

    private void ProcessRaycast() {
        RaycastHit hit;
        if (Physics.Raycast(this.FPCamera.transform.position, this.FPCamera.transform.forward, out hit, this.range)) {
            Debug.Log("I hit this thing: " + hit.transform.name);
            CreateHitImpact(hit);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        } else {
            //return;
        }
    }

    private void CreateHitImpact(RaycastHit hit) {
        GameObject impact = Instantiate(this.hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }
}