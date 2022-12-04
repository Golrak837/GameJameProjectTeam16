using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuHUB : MonoBehaviour
{
    public static bool gamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject HowToPlay;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamePaused)
            {
                Resume();
            }
            else
            {
                pauseMenuUI.SetActive(true);
                gamePaused = true;

            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        gamePaused = false;
    }

    public void MainTitle()
    {
        Resume();
        SceneManager.LoadScene("MainTitle");
    }

    public void HowToPLay()
    {
        HowToPlay.SetActive(true);
    }
    public void HowToPLayBack()
    {
        HowToPlay.SetActive(false);
    }
}
