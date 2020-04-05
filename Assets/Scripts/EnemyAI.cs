using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    [SerializeField] Transform target;
    [SerializeField] float chaseRange = 10f;
    [SerializeField] float turnSpeed = 5f;
    NavMeshAgent navMeshAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    EnemyHealth health;
    CapsuleCollider collider;

    void Start() {
        this.navMeshAgent = GetComponent<NavMeshAgent>();
        this.health = GetComponent<EnemyHealth>();
        this.collider = GetComponent<CapsuleCollider>();
    }

    void Update() {
        if (health.IsDead()) {
            this.enabled = false;
            this.navMeshAgent.enabled = false;
            this.collider.enabled = false;
            return;
        }
        this.distanceToTarget = Vector3.Distance(target.position, transform.position);

        if (this.isProvoked) {
            EngageTarget();
        } else if (this.distanceToTarget <= this.chaseRange) {
            this.isProvoked = true;
        }
    }

    public void OnDamageTaken() {
        this.isProvoked = true;
    }

    private void EngageTarget() {
        FaceTarget();
        if (this.distanceToTarget > this.navMeshAgent.stoppingDistance) {
            ChaseTarget();
        }

        if (this.distanceToTarget <= this.navMeshAgent.stoppingDistance) {
            AttackTarget();
        }
    }

    private void ChaseTarget() {
        this.GetComponent<Animator>().SetBool("attack", false);
        this.GetComponent<Animator>().SetTrigger("move");
        this.navMeshAgent.SetDestination(this.target.position);
    }

    private void AttackTarget() {
        this.GetComponent<Animator>().SetBool("attack", true);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(this.transform.position, this.chaseRange);
    }

    private void FaceTarget() {
        Vector3 direction = (this.target.position - this.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookRotation, Time.deltaTime * this.turnSpeed);
    }
}