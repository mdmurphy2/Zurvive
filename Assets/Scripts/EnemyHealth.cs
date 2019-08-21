﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;
    [SerializeField] RoundContoller roundController;

    bool isDead = false;

    public void Start() {
        roundController = GetComponentInParent<RoundContoller>();
    }


    public void TakeDamage(float damage) {

        //Provoke Enemy
        BroadcastMessage("OnDamageTaken");

        hitPoints -= damage;
        if(hitPoints <= 0) {
            Die();   
        }
    }

    public bool IsDead() {
        return isDead;
    }

    private void Die() {

        if(transform.name == "Elephant") {
            Destroy(gameObject);
        }
        if (isDead) return; //So doesnt trigger death multiple times

        GetComponent<Animator>().SetTrigger("death");
        isDead = true;

        roundController.decreaseZombiesRemaining();


    }
}
