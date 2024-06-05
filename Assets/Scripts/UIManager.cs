using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    public EventSystem eventSystem;
    public static UIManager Instance;

    AudioManager audioManager;

    [Header ("---------Main Menu---------")]
    public GameObject newGameButton;
    public GameObject settingsButton;
    public GameObject quitButton;

    [Header ("---------Settings---------")]
        public GameObject volumeSlider;
        public GameObject sfxSlider;
        public GameObject backButton;

    [Header ("---------Name Input---------")]
    public GameObject inputField;
    public GameObject submitButton;

    [Header("---------High Score---------")]
    public GameObject highScoreView;
    public GameObject highScore;

    [Header ("------------Views------------")]
    public GameObject settingsView;
    public GameObject mainMenuView;
    public GameObject nameInputView;


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        audioManager = AudioManager.Instance;
        eventSystem = EventSystem.current;

    }
    public void StartGame()
    {   

        audioManager.PlayMenuSelect();
        GameManager.Instance.LoadScene("Level");
    }

    public void ShowNameSelect()
    {
        audioManager.PlayMenuSelect();
        mainMenuView.SetActive(false);
        nameInputView.SetActive(true);
        eventSystem.SetSelectedGameObject(inputField);
    }

    public void ShowSettings()
    {
        bool isActive = settingsView.activeSelf;
        audioManager.PlayMenuSelect();
        //highScoreView.SetActive(isActive);
        if(!isActive)
        {
            eventSystem.SetSelectedGameObject(volumeSlider);
        }
        else
        {
            AudioManager.Instance.PlayMenuSelect();
            eventSystem.SetSelectedGameObject(newGameButton);
        }
        mainMenuView.SetActive(isActive);
        settingsView.SetActive(!isActive);
    }

    public void ChangeMusicVolume()
    {
        float volume = volumeSlider.GetComponent<UnityEngine.UI.Slider>().value;
        audioManager.SetMusicVolume(volume);
        
    }

    public void ChangeSFXVolume()
    {
        float volume = sfxSlider.GetComponent<UnityEngine.UI.Slider>().value;
        audioManager.SetSFXVolume(volume);
    }

    public void QuitGame()
    {
        AudioManager.Instance.PlayMenuSelect();
        Debug.Log("Thanks for playing");
        GameManager.Instance.QuitGame();
    }


}
