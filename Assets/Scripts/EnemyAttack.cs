using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    PlayerHealth target;
    [SerializeField] float damage = 40f;

    ZombieAudio zombieAudio;



    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
        zombieAudio = GetComponent<ZombieAudio>();
    }


    public void AttackhitEvent() {
        if(target == null) {
            return;
        }

        target.TakeDamage(damage);
        target.GetComponent<DisplayDamage>().showDamageAttack();
        zombieAudio.playAttackSound();
    }

}
