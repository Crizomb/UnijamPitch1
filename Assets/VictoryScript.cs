using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScript : MonoBehaviour
{
    [SerializeField] private GameObject VictoryPanel;

    public void Pause()
    {
        VictoryPanel.SetActive(true);
        SoundSingleton.Instance.PlayWin();
        Time.timeScale = 0f;
    }

}
