using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundContoller : MonoBehaviour
{

    [SerializeField] float timeBetweenRounds = 10f;
    [SerializeField] float displayUITime = 1f;
    [SerializeField] TMPro.TextMeshProUGUI zombieText;
    [SerializeField] Canvas roundCanvas;

    TextMeshPro text;
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
        zombieText.SetText("Zombies - " + zombiesRemaining);

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

        StartCoroutine(ShowRound());

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

    IEnumerator ShowRound() {
        int wave = currentWaveIndex;

        roundCanvas.transform.GetChild(wave).gameObject.SetActive(true);
        yield return new WaitForSeconds(displayUITime);
        roundCanvas.transform.GetChild(wave).gameObject.SetActive(false);
    }
}
