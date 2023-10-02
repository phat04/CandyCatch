using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    int score = 0;
    bool gameOver;
    int lives = 3;

    [SerializeField] Text scoreText;
    [SerializeField] GameObject livesPanel;
    [SerializeField] GameObject gameOverPanel;

    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore()
    {
        if (!gameOver)
        {
            score++;
            scoreText.text = score.ToString();
        }
        //print(score);
    }

    public void DecreaseLife()
    {
        if (lives > 0 )
        {
            lives--;
            print(lives);

            livesPanel.transform.GetChild(lives).gameObject.SetActive(false);
        }

        if (lives <= 0)
        {
            gameOver = true;

            GameOver();
        }
    }

    void GameOver()
    {
        CandySpawner.instance.StopSpawnCandies();

        GameObject.Find("Player").GetComponent<PlayerController>().canMove = false;

        gameOverPanel.SetActive(true);

        print("GameOver");
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
