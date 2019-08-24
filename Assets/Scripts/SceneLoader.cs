using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void ReloadGame() {
        SceneManager.LoadScene(1); //Loads Main scene
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
    }

    public void QuitGame() {
        Application.Quit();
    }
}
