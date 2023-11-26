using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public void Play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("");
    }

    public void Options()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Options");
    }

    public void Credits1()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Crédits1");
    }

    public void Credits2()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Crédits2");
    }

    public void Menu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MenuPrincipal");
    }


    public void Quit()
    {
        Application.Quit();
    }
}