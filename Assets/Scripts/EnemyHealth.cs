using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    bool isDead = false;



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
        if (isDead) return; //So doesnt trigger death multiple times

        GetComponent<Animator>().SetTrigger("death");
        isDead = true;
        
    }
}
