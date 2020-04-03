using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour {

    [SerializeField] Camera fpsCamera;
    [SerializeField] RigidbodyFirstPersonController fpsController;
    [SerializeField] float zoomedOutFOV = 60f;
    [SerializeField] float zoomedInFOV = 20f;
    [SerializeField] float zoomedOutSensitivity = 2f;
    [SerializeField] float zoomedInSensitivity = .5f;

    bool zoomedInToggle = false;

    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            if (!zoomedInToggle) {
                zoomedInToggle = true;
                this.fpsCamera.fieldOfView = this.zoomedInFOV;
                this.fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
                this.fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
            } else {
                zoomedInToggle = false;
                this.fpsCamera.fieldOfView = this.zoomedOutFOV;
                this.fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
                this.fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
            }
        }
    }

}