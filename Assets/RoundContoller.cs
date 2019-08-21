﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoundContoller : MonoBehaviour
{

    [SerializeField] float timeBetweenRounds = 2f;
    
    
    int currentWaveIndex;
    int zombiesRemaining;

    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentWaveIndex = 0;
        SetWave();
    }

    // Update is called once per frame
    void Update()
    {
        if(zombiesRemaining <= 0) {
            if(timer >= timeBetweenRounds) {
                currentWaveIndex++;
                SetWave();
                Debug.Log("advanced Wave");
            } else {
                timer += Time.deltaTime;
            }
            
        }
    }

    public void decreaseZombiesRemaining() {
        zombiesRemaining--;
    }

   
    private void SetWave() {
        int waveIndex = 0;

        foreach (Transform wave in transform) {
            if (waveIndex == currentWaveIndex) {
                wave.gameObject.SetActive(true);
                zombiesRemaining = wave.gameObject.transform.childCount;
                Debug.Log(zombiesRemaining);
            } else {
                wave.gameObject.SetActive(false);
            }
            waveIndex++;
        }
    }
}
