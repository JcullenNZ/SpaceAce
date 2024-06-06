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

    [Header("---------Wave Elements---------")]
    public TextMeshProUGUI waveFinishedText;
    public TextMeshProUGUI waveStartText;
    public TextMeshProUGUI countdownText;
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
        if(timerActive){
        TimeCountDown();
        }

    }

    //****System Inits****

    void OnEnable() //Subcribing to Actions
    {
        controls.Enable();
        EnemyHealth.OnEnemyDeath += HandleOnEnemyDeath;
        WaveManager.OnWaveComplete += HandleWaveComplete;
        WaveManager.OnNewWaveStart += HandleWaveStart;
        PlayerHealth.OnPlayerDeath += EndGame;
    }

    void OnDisable() //Unsubscribing from Actions
    {
        controls.Disable();
        EnemyHealth.OnEnemyDeath -= HandleOnEnemyDeath;
        WaveManager.OnWaveComplete -= HandleWaveComplete;
        WaveManager.OnNewWaveStart -= HandleWaveStart;
        PlayerHealth.OnPlayerDeath -= EndGame;
    }

    //****Handling Wave Actions****
    private void HandleWaveComplete(int waveScore)
    {
        int score = int.Parse(scoreText.text);
        score += waveScore;
        SetScoreText(score);
        GameManager.Instance.playerScore = score;
        timerActive = false; //Pause timer
        waveFinishedText.gameObject.SetActive(true);
    }

    private void HandleWaveStart(int waveTime, int waveNumber, float timeBetweenWaves)
    {
        StartCoroutine(TimeUntilWaveStart(waveTime,waveNumber, timeBetweenWaves));
    }

    private IEnumerator TimeUntilWaveStart(int waveTime, int waveNumber, float timeBetweenWaves)
    {
        SetWaveTimer(waveTime); //Time to beat the wave
        waveStartText.gameObject.SetActive(true);
        countdownText.gameObject.SetActive(true);
        waveStartText.text = "Wave " + waveNumber.ToString() + " Begins in";
        countdownText.text = timeBetweenWaves.ToString();
        yield return WaveCountDown(timeBetweenWaves); //Countdown to wave start
        waveFinishedText.gameObject.SetActive(false);
        waveStartText.gameObject.SetActive(false);
        countdownText.gameObject.SetActive(false);
        timerActive = true; //Reset Timer
    }

        public void SetWaveTimer(float waveTime) //Allows it to be set by Wave Manager
    {
        timer = waveTime;
        SetTimeText();
    }

    private IEnumerator WaveCountDown(float timeBetweenWaves)
    {   
        while (timeBetweenWaves > 0)
        {
            timeBetweenWaves -= Time.deltaTime;
            int timeBetweenWavesInt = Mathf.RoundToInt(timeBetweenWaves);
            countdownText.text = timeBetweenWavesInt.ToString();
            yield return null;
        }
        Debug.Log("Wave Starts");

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
        GameManager.Instance.playerScore = score;
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

    public void TimeCountDown()
    {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = 0;
                Debug.Log("Game Over");
                PlayerHealth.Instance.Die(); //Player dies when timer runs out, NEED TO HANDLE WAVE AGAIN
            }
            SetTimeText();
    }


    // ****In Game Functions***
    public void PauseGame()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        eventSystem.SetSelectedGameObject(musicSlider);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        eventSystem.SetSelectedGameObject(null);
        pauseMenu.SetActive(false);
    }

    public void EndGame()
    {
        Time.timeScale = 1f;
        GameManager.Instance.EndGame();
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
