using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using TMPro;
using System.Collections;

public class GameUIManager : MonoBehaviour
{
    public EventSystem eventSystem;
    public static GameUIManager Instance;

    public static PlayerControls controls;

    AudioManager audioManager;

    [Header("---------UI Elements---------")]
    public GameObject pauseMenu;
    public TextMeshProUGUI playerNameObj;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;

    [Header("---------Pause Menu---------")]
    public GameObject resumeButton;
    public GameObject musicSlider;
    public GameObject sfxSlider;
    public GameObject quitButton;

    [Header("---------Countdown Timer---------")]
    public float countdownTime = 30f; //Initialise in inspector
    private float timer;

    private bool timerActive = false;

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

    void Start()
    {
        timer = countdownTime; //Initialise timer - will be set by Wave Manager
        SetPlayerName();
        SetScoreText(0);
        SetTimeText();
    }

    void Update()
    {
        TimeCountDown();

    }

    //****System Inits****

    void OnEnable() //Subcribing to Actions
    {
        controls.Enable();
        EnemyHealth.OnEnemyDeath += HandleOnEnemyDeath;
        WaveManager.OnWaveComplete += HandleWaveComplete;
        WaveManager.OnNewWaveStart += HandleWaveStart;
    }

    void OnDisable() //Unsubscribing from Actions
    {
        controls.Disable();
        EnemyHealth.OnEnemyDeath -= HandleOnEnemyDeath;
        WaveManager.OnWaveComplete += HandleWaveComplete;
        WaveManager.OnNewWaveStart += HandleWaveStart;
    }

    //****Handling Wave Actions****
    private void HandleWaveComplete(int waveScore)
    {
        int score = int.Parse(scoreText.text);
        score += waveScore;
        SetScoreText(score);
        timerActive = false;
    }

    private void HandleWaveStart(int waveTime, int waveNumber, float timeBetweenEnemies)
    {

        StartCoroutine(TimeUntilWaveStart(waveNumber, timeBetweenEnemies));
        SetWaveTimer(waveTime);
        timerActive = true;
    }

    private IEnumerator TimeUntilWaveStart(int waveNumber, float timeBetweenEnemies)
    {
        Debug.Log("Wave " + waveNumber + " starting in " + timeBetweenEnemies + " seconds");
        yield return new WaitForSeconds(timeBetweenEnemies);
    }



    //****Set UI Text Functions****
    //Get Player Name from GameManager

    void SetPlayerName()
    {
        string playerName = GameManager.Instance.playerName;
        playerNameObj.text = playerName;
    }


    void HandleOnEnemyDeath(int scoreValue)
    {
        int score = int.Parse(scoreText.text);
        score += scoreValue;
        SetScoreText(score);
    }
    void SetScoreText(int score)
    {
        scoreText.text = score.ToString();
    }

    //****Set Time Text Function****
    void SetTimeText()
    {
        int time = Mathf.RoundToInt(timer);
        timeText.text = time.ToString();
    }

    public void SetWaveTimer(float waveTime) //Allows it to be set by Wave Manager
    {
        timer = waveTime;
        SetTimeText();
    }

    public void TimeCountDown()
    {
        if (timerActive)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                Debug.Log("Game Over");
                PlayerHealth.Instance.Die();
            }
            SetTimeText();
        }
        else
        {
            SetTimeText();
        }
    }


    // ****In Game Functions***
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
    // ****Pause Menu Functions***
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
