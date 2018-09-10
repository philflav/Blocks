﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float speed;

    public Text livesText;
    public int livesRemaining;

    public Text timeRemaining;
    public float gameTime;

    public Text scoreText;

    private float time;

    public GameObject gameOverScreen;
    public GameObject levelCompleteScreen;


    private BallController ball;
    private int gamescore;

    public bool gameActive;

    private void Start()
    {
        ball = FindObjectOfType<BallController>();
        livesText.gameObject.SetActive(true);
        timeRemaining.gameObject.SetActive(true);
        livesText.text = "Lives: " + livesRemaining;
        time = gameTime;
        timeRemaining.text = "Time: " + time;
        gamescore = 0;
        scoreText.text = "";
    }

    private void Update()
    {
        //countdown timer for game
        time = time - Time.deltaTime;

        scoreText.text = "Score: " + gamescore;

        if (time < 0)
        {
            ball.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
            livesText.gameObject.SetActive(false);
        }
        else
        {
        timeRemaining.text = "Time: " + time.ToString("n0");
        }

        //get number of bricks left and set Level Complete if null
        var BrickCheck = FindObjectOfType<BrickController>();
        if (BrickCheck == null)
        {
            levelCompleteScreen.SetActive(true);
            ball.gameObject.SetActive(false);
        }
    }

    public void RespawnBall()
    {
        gameActive = false;
        livesRemaining -= 1;

        if (livesRemaining < 0)
        {
            livesText.text = "All lives lost";
            ball.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
            timeRemaining.gameObject.SetActive(false);

        }
        else
        {
        livesText.text = "Lives: " + livesRemaining;
        }

    }
    public void AddScore(int value)
    {
        gamescore += value;
        Debug.Log(gamescore);
    }

    
}
