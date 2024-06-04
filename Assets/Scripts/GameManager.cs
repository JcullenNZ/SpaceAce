using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System.IO;
using UnityEditor;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    private Scene currentScene;
    private bool IsPaused = false;
    private string highScoresFP;

    public static event Action<string> OnSceneLoaded;

    public enum GameState { MainMenu, InGame, Paused, GameOver };
    public GameState currentState;

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
        LoadScene("SampleScene");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        OnSceneLoaded?.Invoke(sceneName);
        Debug.Log("Scene Loaded: " + sceneName);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
    public void EndGame(int score, string playerName)
    {
        if (HighScoreManager.Instance.IsHighScore(score))
        {
            HighScoreManager.Instance.AddHighScore(playerName, score);
        }
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

}

