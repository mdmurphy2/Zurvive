using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{

    [SerializeField] Canvas damageCanvas;
    [SerializeField] float damageTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        damageCanvas.enabled = false;
    }

    public void showDamageAttack() {
        StartCoroutine(ShowDamage());
    }

    IEnumerator ShowDamage() {
        damageCanvas.enabled = true;
        yield return new WaitForSeconds(damageTime);
        damageCanvas.enabled = false;
    }
}
