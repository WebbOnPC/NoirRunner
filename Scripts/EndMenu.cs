using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour
{
    public string MainMenu;
    public string Level;

    public GameObject winnerScreen;

    public void QuitToMain()
    {
        winnerScreen.gameObject.SetActive(false);
        SceneManager.LoadScene(MainMenu);
    }
    public void Replay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(Level);
    }
}

