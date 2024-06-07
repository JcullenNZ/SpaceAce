using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class GameOverUIManager : MonoBehaviour
{
    public static GameOverUIManager Instance;

    GameManager gameManager;

    [Header("---------UI Elements---------")]
    public GameObject PlayerName;
    public GameObject PlayerScore;
    public GameObject HighScoreAlert;   

    public GameObject GameName;
    public GameObject GameOverText;

    //Timer things
    private float timer = 0f;
    private float interval = 2f;

    bool flash = true;

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
        gameManager = GameManager.Instance;

    }

    void Start()
    {
        DisplayGameOverUI();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= interval)
        {
            timer = 0;
            GameName.SetActive(flash);
            GameOverText.SetActive(!flash);
            flash = !flash;
        }
    }

    public void StartGame()
    {
        gameManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        gameManager.QuitGame();
    }   

    public void DisplayGameOverUI()
    {
        
        if(HighScoreManager.Instance.isHighScore)
        {
            HighScoreAlert.SetActive(true);
            PlayerName.SetActive(false);
            PlayerScore.SetActive(false);
        }
        else
        {
            HighScoreAlert.SetActive(false);
             PlayerName.SetActive(true);
             PlayerScore.SetActive(true);
        }

        PlayerName.GetComponent<TMPro.TextMeshProUGUI>().text = "Player: " + gameManager.playerName;
        PlayerScore.GetComponent<TMPro.TextMeshProUGUI>().text = "Score: " + gameManager.playerScore;
    }


}
