using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;
    [SerializeField]
    private AudioMixer audioMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

[Header("------Audio Sources------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    //*-------Add audio sources for music and sfx------*//
[Header("------Audio Clips: MUSIC------")]
public AudioClip mainMenuMusic;
public AudioClip gameMusic1;
public AudioClip gameMusic2;
[Header("------Audio Clips: SFX------")]
public AudioClip menuSelect;


    public Music currentSong = null;
    void Awake()
    {
        //Ensure singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        musicSource.clip = mainMenuMusic;
        musicSource.Play();
    }


    public void PlaySFX(AudioClip clip)
    {
        sfxSource.PlayOneShot(clip);
        sfxSource.Play();
    }

    public void PlayMenuSelect()
    {
        sfxSource.PlayOneShot(menuSelect);
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    private float ValueToVolume(float value, float maxVolume)
    {
        return Mathf.Log10(Mathf.Clamp(value,0.0001f,1f) * (maxVolume - 0.0001f)/ 4 +maxVolume);
    }
    public void SetMusicVolume()
    {
        float volume = musicSlider.value;
        //audioMixer.SetFloat("MusicVol", ValueToVolume(volume, 1f));
        audioMixer.SetFloat("MusicVol", Mathf.Log10(volume) * 20);
        Debug.Log("Music Volume: " + volume);

    }

    public void SetSFXVolume()
    {
        float volume = sfxSlider.value;
        audioMixer.SetFloat("SFXVol", Mathf.Log10(volume) * 20);
        Debug.Log("SFX Volume: " + volume); 
    }
}

