using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

    [SerializeField] float hitPoints = 100f;

    bool isDead = false;

    public bool IsDead() {
        return this.isDead;
    }

    public void TakeDamage(float damage) {
        BroadcastMessage("OnDamageTaken");
        hitPoints -= damage;
        if (hitPoints <= 0) {
            Die();
        }
    }

    private void Die() {
        if (this.isDead) return;
        this.isDead = true;
        this.GetComponent<Animator>().SetTrigger("die");
    }
}