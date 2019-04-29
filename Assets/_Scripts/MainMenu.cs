using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void DoubleBattle()
    {
        SceneManager.LoadScene("DoubleBattle");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Search");
    }
    public void QuitGame()
    {
        Debug.Log("Quit Game!!!");
        Application.Quit();
    }
}
