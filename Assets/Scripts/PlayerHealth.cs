using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    [SerializeField] float healthPoints = 150f;

    public void TakeDamage(float damage) {
        healthPoints -= damage;
        if (healthPoints <= 0) {
            Debug.Log("Wake up, you're dead !");
        }
    }

}