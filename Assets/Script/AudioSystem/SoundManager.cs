using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance = null;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource buttonsMenuSource = null;
    [SerializeField] private AudioSource raceSoundsSource = null;
    [SerializeField] private AudioSource playerSoundsSource = null;

    [Header("MainMenuSFX")]
    [SerializeField] private AudioClip buttonChanged = null;
    [SerializeField] private AudioClip buttonSelect = null;

    [Header("RaceSFX")]
    [SerializeField] private AudioClip countdownRace = null;
    
    [Header("PlayerSFX")]
    [SerializeField] private AudioClip playerWings = null;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }

    private void PlaySFX(AudioSource aSorce)
    {
        aSorce.pitch = 1 + Random.Range(-0.15f, 0.15f);
        aSorce.Play();
    }

    #region Main Menu Sounds

    public void PlayUIChangeButton()
    {
        buttonsMenuSource.clip = buttonChanged;
        PlaySFX(buttonsMenuSource);
    }
    
    public void PlayUISelectButton()
    {
        buttonsMenuSource.clip = buttonSelect;
        PlaySFX(buttonsMenuSource);
    }

    #endregion

    #region Racing Sounds

    public void PlayStartSounds()
    {
        raceSoundsSource.clip = countdownRace;
        PlaySFX(raceSoundsSource);
    }

    #endregion
    
    #region Player Sounds

    public void PlayWingsSounds()
    {
        playerSoundsSource.clip = playerWings;
        PlaySFX(playerSoundsSource);
    }

    #endregion
}
