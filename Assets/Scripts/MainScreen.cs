using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScreen : MonoBehaviour {

    private float countDown = 5f;

    public Text countDownText;
    public int startLives;
    public AudioSource hiscoreSound;

    // Use this for initialization
    void Start () {
        PlayerPrefs.SetInt("currentScore", 0);
        PlayerPrefs.SetInt("currentLives", 4);
    }
	
    public void NewGame()
    {
        PlayerPrefs.SetInt("currentScore", 0);
        PlayerPrefs.SetInt("currentLives", 4);
        SceneManager.LoadScene("Main");
    }
    public void ResetHiScore()
    {
        PlayerPrefs.SetInt("hiscore", 0);
        hiscoreSound.Play();
    }

	// Update is called once per frame
	void Update () {

        countDown -= Time.deltaTime;

        countDownText.text = "" + countDown.ToString("n0");

        if (countDown < 0)
        {
            SceneManager.LoadScene("Level1");
        }
		
	}
}
