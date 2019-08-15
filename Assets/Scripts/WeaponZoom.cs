using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{

    [SerializeField] Camera mainCamera;
    [SerializeField] Camera gunCamera;
    [SerializeField] RigidbodyFirstPersonController rbController;
    [SerializeField] float normalFov = 60f;
    [SerializeField] float zoomedFov = 20f;
    [SerializeField] float normalSens = 1f;
    [SerializeField] float zoomedSens = .5f;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)) {
            mainCamera.fieldOfView = zoomedFov;
            gunCamera.fieldOfView = zoomedFov;
            rbController.mouseLook.XSensitivity = zoomedSens;
            rbController.mouseLook.YSensitivity = zoomedSens;
            
        } else {
            mainCamera.fieldOfView = normalFov;
            gunCamera.fieldOfView = normalFov;
            rbController.mouseLook.XSensitivity = normalSens;
            rbController.mouseLook.YSensitivity = normalSens;
        }
    }
}
