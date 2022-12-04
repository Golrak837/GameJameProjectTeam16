using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;

    public GameObject pauseMenuUI;
    public GameObject HowToPlay;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(gamePaused)
            {
                Resume();
            }
            else
            {
                GameObject.Find("Japanese_char").GetComponent<AudioSource>().Stop();
                GameObject.Find("Belgian_char").GetComponent<AudioSource>().Stop();
                pauseMenuUI.SetActive(true);
                Time.timeScale = 0;
                gamePaused = true;

            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gamePaused = false;
    }

    public void LoadHub()
    {
        Resume();
        SceneManager.LoadScene("Hub");
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
