using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("");
    }

    public void Settings()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("");
    }

    public void Credits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("");
    }

    public void Quit()
    {
        Application.Quit();
    }
}