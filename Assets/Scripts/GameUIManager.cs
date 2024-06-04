using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class GameUIManager : MonoBehaviour
{
    public EventSystem eventSystem;
    public static GameUIManager Instance;

    public static PlayerControls controls;

    AudioManager audioManager;

    [Header ("---------UI Elements---------")]
    public GameObject pauseMenu;

    [Header ("---------Pause Menu---------")]
    public GameObject resumeButton;
    public GameObject musicSlider;
    public GameObject sfxSlider;
    public GameObject quitButton;

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
       
        controls = new PlayerControls();
        controls.InGame.Pause.performed += ctx => PauseGame();

    }

    void OnEnable()
    {   
        controls.Enable();
    }

    void OnDisable()
    {
        controls.Disable();
    }

    
    public void PauseGame()
    {
        //controls.Disable();
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        eventSystem.SetSelectedGameObject(musicSlider);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        eventSystem.SetSelectedGameObject(null);
        pauseMenu.SetActive(false);
        //controls.Enable();
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        GameManager.Instance.LoadScene("SampleScene");
    }

    public void ChangeMusicVolume()
    {
        float volume = musicSlider.GetComponent<UnityEngine.UI.Slider>().value;
        audioManager.SetMusicVolume(volume);
    }

    public void ChangeSFXVolume()
    {
        float volume = sfxSlider.GetComponent<UnityEngine.UI.Slider>().value;
        audioManager.SetSFXVolume(volume);
    }

}
