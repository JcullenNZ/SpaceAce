
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEditor;
using System;
using UnityEngine.InputSystem;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Scene currentScene;
    private bool IsPaused = false;
    private string highScoresFP;

    public static event Action<string> OnSceneLoaded;

    public enum GameState { MainMenu, InGame, Paused, GameOver };
    public GameState currentState;

    public string playerName;
    public int playerScore;

    private void Awake()
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

        currentState = GameState.MainMenu;

        
    }

    void Start()
    {
        Debug.Log("GameManager start");
        LoadScene("MainMenu");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        OnSceneLoaded?.Invoke(sceneName);
        Debug.Log("Scene Loaded: " + sceneName);
        if(sceneName == "MainMenu") //Reset player name and score
        {
            playerName = "";
            playerScore = 0;
        }
        
    }



    public void QuitGame()
    {
        Debug.Log("QUIT");
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
    public void EndGame()
    {
        HighScoreManager.Instance.AddHighScore(playerName, playerScore);
        ChangeState(GameState.GameOver);
        SceneManager.LoadScene("GameOver");
    }

    public void PauseGame()
    {
        if (currentState == GameState.InGame)
        {
            if (IsPaused == false)
            {
                IsPaused = true;
                ChangeState(GameState.Paused);
            }
            else
                IsPaused = false;
            ChangeState(GameState.InGame);
        }
    }

    public void ChangeState(GameState newState)
    {
        currentState = newState;
    }

    public void SetPlayerName(string name)
    {
        playerName = name;
    }

    public string GetPlayerName()
    {
        return playerName;
    }   

    public void SetPlayerScore(int score)
    {
        playerScore = score;
    }

    public int GetPlayerScore()
    {
        return playerScore;
    }

}

