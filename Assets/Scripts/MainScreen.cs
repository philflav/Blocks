using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScreen : MonoBehaviour {

    private float countDown = 10f;

    public Text countDownText;

	// Use this for initialization
	void Start () {
		
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
