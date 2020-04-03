using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour {

    [SerializeField] int currentWeapon = 0;

    void Start() {
        SetWeaponActive();
    }

    void Update() {

        int previousWeapon = this.currentWeapon;
        ProcessKeyInput();
        ProcessScrollWheel();

        if (previousWeapon != this.currentWeapon) {
            SetWeaponActive();
        }

    }

    private void ProcessScrollWheel() {
        if (Input.GetAxis("Mouse ScrollWheel") > 0) {
            if (this.currentWeapon >= this.transform.childCount - 1) {
                this.currentWeapon = 0;
            } else {
                this.currentWeapon++;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0) {
            if (this.currentWeapon <= 0) {
                this.currentWeapon = this.transform.childCount - 1;
            } else {
                this.currentWeapon--;
            }
        }

    }

    private void ProcessKeyInput() {
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            this.currentWeapon = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) {
            this.currentWeapon = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) {
            this.currentWeapon = 2;
        }
    }

    private void SetWeaponActive() {
        int weaponIndex = 0;
        foreach (Transform weapon in this.transform) {
            if (weaponIndex == this.currentWeapon) {
                weapon.gameObject.SetActive(true);
            } else {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }
}