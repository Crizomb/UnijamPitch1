using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryScript : MonoBehaviour
{
    [SerializeField] private GameObject VictoryPanel;

    public void Victory()
    {
        VictoryPanel.SetActive(true);
        SoundSingleton.Instance.PlayWin();
    }

}
