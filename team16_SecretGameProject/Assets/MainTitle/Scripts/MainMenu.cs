using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        PlayerPrefs.SetInt("Fire",0);
        PlayerPrefs.SetInt("Earth",0);
        PlayerPrefs.SetInt("Water",0);
        PlayerPrefs.SetInt("Wind",0);
        PlayerPrefs.SetInt("Void",0);
        PlayerPrefs.SetInt("TreeStatus",0);
        SceneManager.LoadScene("Hub");
    }

    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitGame()
    {
        Debug.Log("Key!");
        Application.Quit();
    }
}
