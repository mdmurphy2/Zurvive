using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] float hitPoints = 100f;

    RoundContoller roundController;
    ZombieAudio zombieAudio;

    bool isDead = false;

    public void Start() {
        roundController = GetComponentInParent<RoundContoller>();
        zombieAudio = GetComponent<ZombieAudio>();
    }


    public void TakeDamage(float damage) {

        //Provoke Enemy
        BroadcastMessage("OnDamageTaken");
        zombieAudio.playDamageSound();

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
        GetComponent<CapsuleCollider>().enabled = false;
        isDead = true;

        roundController.decreaseZombiesRemaining();


    }
}
