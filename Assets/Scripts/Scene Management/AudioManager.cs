using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("---------- Audio Clip ----------")]
    public AudioClip background;
    public AudioClip dashSound;
    public AudioClip slashSound;
    public AudioClip arrowSound;
    public AudioClip magicSound;
    public AudioClip hit01Sound;
    public AudioClip hit02Sound;
    public AudioClip destructibleSound;
    public AudioClip healthSound;
    public AudioClip coinSound;
    public AudioClip staminaSound;
    public AudioClip click01Sound;
    public AudioClip click02Sound;
    public AudioClip click03Sound;

    private void Start()
    {
        LowerMusicVolume(0.1f);

        musicSource.clip = background;
        musicSource.Play();
    }

    private void LowerMusicVolume(float volumeMultiplier)
    {
        musicSource.volume *= volumeMultiplier;
    }

    public void PlaySFX(AudioClip clip, float volume = 1.0f)
    {
        SFXSource.PlayOneShot(clip, volume);
    }

}
