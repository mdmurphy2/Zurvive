using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] float hitPoints = 100f;
    [SerializeField] Slider slider;

    

    // Start is called before the first frame update
    void Start()
    {
        slider = slider.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = hitPoints;
    }
    

    public void TakeDamage(float damage) {
        hitPoints -= damage;
           
        if (hitPoints <= 0) {
            GetComponent<DeathHandler>().HandleDeath();
        }
    }
}
