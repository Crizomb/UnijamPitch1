using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused;
    [SerializeField] private GameObject pauseMenuUI;

    private void Start()
    {
        Resume();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Menu()
    {
        SoundSingleton.Instance.PlayClick();
        SceneManager.LoadScene("MenuPrincipal");
    }

    public void Options()
    {
        SoundSingleton.Instance.PlayClick();
        SceneManager.LoadScene("Options", LoadSceneMode.Additive);
        
    }

    public void Quit()
    {
        SoundSingleton.Instance.PlayClick();
        Application.Quit();
    }

}
