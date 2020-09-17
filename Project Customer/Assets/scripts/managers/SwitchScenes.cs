using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void LoadLoseScreen()
    {
        SceneManager.LoadScene("RestartScreen");
    }

    public void LoadStart()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void LoadWinScreen()
    {
        SceneManager.LoadScene("win menu");
    }
}