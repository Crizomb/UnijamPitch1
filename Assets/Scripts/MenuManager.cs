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
        SceneManager.LoadScene("Lvl tuto");
    }

    public void Options()
    {
        SoundSingleton.Instance.PlayClick();
        SceneManager.LoadScene("Options", LoadSceneMode.Additive);
    }

    public void Credits1()
    {
        SoundSingleton.Instance.PlayClick();
        SceneManager.LoadScene("Crédits1", LoadSceneMode.Additive);
    }

    public void Credits2()
    {
        SoundSingleton.Instance.PlayClick();
        SceneManager.LoadScene("Crédits2", LoadSceneMode.Additive);
    }

    public void GoBack(string scene)
    {
        SoundSingleton.Instance.PlayClick();
        SceneManager.UnloadScene(scene);  
    }


    public void Quit()
    {
        SoundSingleton.Instance.PlayClick();
        Application.Quit();
    }
}