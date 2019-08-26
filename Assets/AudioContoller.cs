using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioContoller : MonoBehaviour {

    [SerializeField] AudioSource gunshot;
    [SerializeField] AudioSource reload;
    [SerializeField] AudioSource empty;



    public void playGunshot() {
        gunshot.Play();
    }

    public void playReload() {
        reload.Play();
    }

    public void playEmpty() {
        empty.Play();
    }


}
