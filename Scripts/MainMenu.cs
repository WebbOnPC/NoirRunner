using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public void PlayEasyGame()
    {
        SceneManager.LoadScene("Easy");
    }

    public void PlayMediumGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Medium");
    }
    public void PlayHardGame()
    {
        SceneManager.LoadScene("Hard");
    }
    public void PlayExpertGame()
    {
        SceneManager.LoadScene("Expert");
    }

    public void HomeMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
