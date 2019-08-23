using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30; //Change based on weapon
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;
    [SerializeField] float rateOfFire = .5f;
    [SerializeField] TMPro.TextMeshProUGUI ammoText;



    bool canShoot = true;

    private void OnEnable() {
        canShoot = true;
    }

    void Update() {
        if (Input.GetMouseButtonDown(0) && canShoot == true) {
            StartCoroutine(Shoot());
        }

        DisplayAmmo();
    }

    private void DisplayAmmo() {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.SetText(currentAmmo.ToString());
    }

    IEnumerator Shoot() {

        if (ammoSlot.GetCurrentAmmo(ammoType) > 0) {
            canShoot = false;
            ammoSlot.ReduceCurrentAmmo(ammoType);
            PlayMuzzleFlash();
            ProcessRaycast();
        }
        yield return new WaitForSeconds(rateOfFire);
        canShoot = true;
    }

    private void PlayMuzzleFlash() {
        muzzleFlash.Play();
    }

    private void ProcessRaycast() {
        RaycastHit hit;
        
        
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range)) {

            CreateHitImpact(hit);

            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return; //If no enemy health 
            target.TakeDamage(damage);
        } else {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit) {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Debug.Log(hit.transform.name);
        Destroy(impact, .1f);

    }
}
