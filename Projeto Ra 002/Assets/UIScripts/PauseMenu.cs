using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject MenusUi;
    public GameObject PauseUi;
    public GameObject OptionsUi;

    //public 
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        MenusUi.SetActive(false);
        PauseUi.SetActive(false);
        OptionsUi.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        MenusUi.SetActive(true);
        PauseUi.SetActive(true);
        OptionsUi.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void RestartCheckpoint()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void RestartBeginning()
    {
        Time.timeScale = 1f;
        RespawnBrain.instance.ResetCheckpoint();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

