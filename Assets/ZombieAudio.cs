using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAudio : MonoBehaviour
{
    public AudioSource[] zombieAudio;
     float zombieMoanTime;
    float timer;
    bool soundPlayed = false;
    //0-2 Zombie Sounds
    //3-4 Zombie Damage Sound
    //5 Zombie Attack Sound


    // Start is called before the first frame update
    void Start()
    {
        zombieMoanTime = Random.Range(5f, 10f);
    }

    private void Update() {
        //if(timer >= zombieMoanTime && !soundPlayed) {
        //    playZombieMoanSound();
        //    soundPlayed = true;
        //} else {
        //    timer += Time.deltaTime;
        //}
    }

    public void playZombieMoanSound() {
       int zombieInt = Random.Range(0, 3);
       zombieAudio[zombieInt].Play();
    }


    public void playDamageSound() {
        int damageIndex = Random.Range(3, 5);
        zombieAudio[damageIndex].Play();
    }

    public void playAttackSound() {
        zombieAudio[5].Play();
    }
}
