using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public TMP_Text playerScore;
    public TMP_Text highScoreText;
    public bool gameStarted;
    public int score = 0;
    public int highScore;
    public void Awake()
    {
        highScoreText.text = $"Best :{GetHighScore().ToString()}";

    }
    public void StartGame()
    {
        gameStarted = true;
        print("Game Starting");
        FindAnyObjectByType<RoadManager>().StartBuilding();


    }

    public void EndGame()
    {
        
        SceneManager.LoadScene(0);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Keyboard.current.enterKey.wasPressedThisFrame) {
            StartGame();
        }
    }

    public void IncreaseScore()
    {
        score++;
        if (score >= highScore)
        {
            PlayerPrefs.SetInt("highScore", score);
            highScoreText.text = $"Best :{score.ToString()}";

        }
        playerScore.text = score.ToString();


    }

    public int GetHighScore()
    {
        int i = PlayerPrefs.GetInt("highScore");

    return i;
    }
}
