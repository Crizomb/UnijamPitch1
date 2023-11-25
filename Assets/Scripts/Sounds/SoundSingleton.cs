using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SoundSingleton : MonoBehaviour
{
    public static SoundSingleton Instance = null;
    
    [Header("Musics")]
    [SerializeField] private AudioClip MenuMusic;
    [SerializeField] private AudioClip GameMusic;

    [Header("Gameplay Sounds")]
    [SerializeField] public AudioClip LiquidJumpSound;
    [SerializeField] public AudioClip SolidJumpSound;
    [SerializeField] private AudioClip ToLiquidSound;
    [SerializeField] private AudioClip ToSolidSound;
    [SerializeField] private AudioClip ToGazSound;

    [Header("UI Sounds")]
    [SerializeField] private AudioClip ClickSound;
    [SerializeField] private AudioClip WinSound;
    [SerializeField] private AudioClip DieSound;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad (gameObject);
    }

    #region Music

    public void PlayMusicMenu()
    {
        SoundManager.Instance.PlayMusic(MenuMusic);
    }
    
    public void PlayMusicGame()
    {
        SoundManager.Instance.PlayMusic(GameMusic);
    }

    #endregion


    #region Sounds

    public void PlayLiquidJump()
    {
        SoundManager.Instance.PlaySound(LiquidJumpSound);
    }

    public void PlaySolidJump()
    {
        SoundManager.Instance.PlaySound(SolidJumpSound);
    }

    public void PlayLiquidTransition()
    {
        SoundManager.Instance.PlaySound(ToLiquidSound);
    }

    public void PlaySolidTransition()
    {
        SoundManager.Instance.PlaySound(ToSolidSound);
    }

    public void PlayGazTransition()
    {
        SoundManager.Instance.PlaySound(ToGazSound);
    }    
    
    public void PlayClick()
    {
        SoundManager.Instance.PlaySound(ClickSound);
    }
    
    public void PlayWin()
    {
        SoundManager.Instance.PlaySound(WinSound);
    }
    
    public void PlayDie()
    {
        SoundManager.Instance.PlaySound(DieSound);
    }
    
    #endregion
}
