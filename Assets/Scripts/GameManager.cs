using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public float speed;

    public Text livesText;
    public int livesRemaining;

    public Text timeRemaining;
    public float gameTime;

    private float time;


    private BallController ball;

    public bool gameActive;

    private void Start()
    {
        ball = FindObjectOfType<BallController>();
        livesText.text = "Lives: " + livesRemaining;
        time = gameTime;
        timeRemaining.text = "Time: " + time;
    }

    private void Update()
    {
        //countdown timer for game
        time = time - Time.deltaTime;
        timeRemaining.text = "Time: " + time.ToString("n1");
    }

    public void RespawnBall()
    {
        gameActive = false;
        livesRemaining -= 1;
        livesText.text = "Lives: " + livesRemaining;
    }

    
}
