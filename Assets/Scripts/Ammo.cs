using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour {

    [SerializeField] AmmoSlot[] ammoSlots;

    [System.Serializable]
    private class AmmoSlot {
        public AmmoType ammoType;
        public int ammoAmount;
    }

    public int GetCurrentAmmo(AmmoType ammoType) {
        return this.GetAmmoSlot(ammoType).ammoAmount;
    }

    public void ReduceCurrentAmmo(AmmoType ammoType) {
        this.GetAmmoSlot(ammoType).ammoAmount--;
    }

    public void IncreaseCurrentAmmo(AmmoType ammoType, int amount) {
        this.GetAmmoSlot(ammoType).ammoAmount += amount;
    }

    private AmmoSlot GetAmmoSlot(AmmoType ammoType) {
        foreach (AmmoSlot slot in this.ammoSlots) {
            if (slot.ammoType == ammoType) {
                return slot;
            }
        }
        return null;
    }

}