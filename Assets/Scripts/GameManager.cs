using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public float speed;
    public float levelTime;

    public Text livesText;
    private int livesRemaining;

    public Text timeRemaining;

    public Text scoreText;
    public Text hiscoreText;

    private float time;

    public GameObject gameOverScreen;
    public GameObject levelCompleteScreen;
    public string nextLevel;


    private BallController ball;
    private int gamescore;
    private int hiscore;

    private GoogleMobileAdsDemo Ad;

    public bool gameActive;



    public AudioSource gameOver;
    public AudioSource ballLost;
    public AudioSource hiscoreSound;

    private void Start()
    {
        livesRemaining = PlayerPrefs.GetInt("currentLives");
        gamescore = PlayerPrefs.GetInt("currentScore");
        hiscore = PlayerPrefs.GetInt("hiscore");
        //load up banner Ad 
        Ad = FindObjectOfType<GoogleMobileAdsDemo>();
        Ad.RequestBanner();
        ball = FindObjectOfType<BallController>();
        livesText.gameObject.SetActive(true);
        timeRemaining.gameObject.SetActive(true);
        livesText.text = "Lives: " + livesRemaining;
        time = levelTime;
        timeRemaining.text = "Time: " + time;
        scoreText.text = "";
        hiscoreText.text = "HiScore: " + hiscore;
        gameOver.Stop();
        ball.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (Ad.interstitial.IsLoaded())
        {
            Ad.interstitial.Show();
        }
        //countdown timer for game
        time = time - Time.deltaTime;

        scoreText.text = "Score: " + gamescore;

        if (time < 0)
        {
            ball.gameObject.SetActive(false);
            if (!gameOverScreen.activeInHierarchy) //check we have not already played gameover sound
            {
                gameOver.Play();
            }
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

    public void NextLevel()
    {
        PlayerPrefs.SetInt("currentScore", gamescore); //save current score to start next level
        PlayerPrefs.SetInt("currentLives", livesRemaining + 2);//add two lives for getting to next level
        SceneManager.LoadScene(nextLevel);
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
            gameOver.Play();

        }
        else
        {
        ballLost.Play();
        livesText.text = "Lives: " + livesRemaining;
        }
        PlayerPrefs.SetInt("currentLives", livesRemaining);
        PlayerPrefs.SetInt("currentScore", gamescore);

    }
    public void AddScore(int value)
    {
        gamescore += value;
        if (gamescore > hiscore)
        {
            hiscore = gamescore;
            PlayerPrefs.SetInt("hiscore", hiscore);
            hiscoreText.text = "HiScore: " + hiscore;
            hiscoreSound.Play();
        }
    }

    public void Quit()
    {
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
        }
        Application.Quit();
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Main");
    }


   


}
