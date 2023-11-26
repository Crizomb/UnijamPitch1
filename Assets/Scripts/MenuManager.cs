using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Start()
    {
        SoundSingleton.Instance.PlayMusicMenu();
    }


    public void Play()
    {
        SoundSingleton.Instance.PlayClick();
        UnityEngine.SceneManagement.SceneManager.LoadScene("");
    }

    public void Options()
    {
        SoundSingleton.Instance.PlayClick();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Options", LoadSceneMode.Additive);
    }

    public void Credits1()
    {
        SoundSingleton.Instance.PlayClick();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Crédits1", LoadSceneMode.Additive);
    }

    public void Credits2()
    {
        SoundSingleton.Instance.PlayClick();
        UnityEngine.SceneManagement.SceneManager.LoadScene("Crédits2", LoadSceneMode.Additive);
    }

    public void Menu()
    {
        SoundSingleton.Instance.PlayClick();
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuPrincipal", LoadSceneMode.Additive);
    }


    public void Quit()
    {
        SoundSingleton.Instance.PlayClick();
        Application.Quit();
    }
}