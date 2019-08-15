using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public void ReloadGame() {
        SceneManager.LoadScene(0); //Loads Main scene
        Time.timeScale = 1;
    }

    public void QuitGame() {
        Application.Quit();
    }
}
