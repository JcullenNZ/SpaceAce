using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    GameManager gameManager;
    public static AudioManager Instance;
    [SerializeField]
    private AudioMixer audioMixer;
    public float musicVolume;
    public float sfxVolume;
   // [SerializeField] private Slider musicSlider;
   // [SerializeField] private Slider sfxSlider;

    [Header("------Audio Sources------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource sfxSource;
    //*-------Add audio sources for music and sfx------*//
    [Header("------Audio Clips: MUSIC------")]
    public AudioClip mainMenuMusic;
    public AudioClip gameMusic1;
    public AudioClip gameOver;
    [Header("------Audio Clips: SFX------")]
    public AudioClip menuSelect;
    public AudioClip menuHover;


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
        GameManager.OnSceneLoaded += HandleOnSceneLoaded;


    }


    private void OnDestroy()
    {
        GameManager.OnSceneLoaded -= HandleOnSceneLoaded;
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

    public void StopMusic()
    {
        musicSource.Stop();
    }

    private void HandleOnSceneLoaded(string sceneName)
    {
        Debug.Log("Scene Loaded: " + sceneName);
        switch (sceneName)
        {
            case "MainMenu":
                Debug.Log("Main Menu playing");
                StopMusic();
                PlayMusic(mainMenuMusic);
                break;
            case "Level":
                Debug.Log("Level playing");
                StopMusic();
                PlayMusic(gameMusic1);
                break;
            case "GameOver":
                Debug.Log("Game Over playing");
                StopMusic();
                PlayMusic(gameOver);
                break;
            default:
                break;
        }


    }

    private float ValueToVolume(float value, float maxVolume)
    {
        return Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1f) * (maxVolume - 0.0001f) / 4 + maxVolume);
    }
    public void SetMusicVolume(float volume)
    {

        audioMixer.SetFloat("MusicVol", Mathf.Log10(volume) * 20);
        Debug.Log("Music Volume: " + volume);
        musicVolume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVol", Mathf.Log10(volume) * 20);
        Debug.Log("SFX Volume: " + volume);
        sfxVolume = volume;
    }
}

