using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour {

    public GameObject scoreEffect;
    public int BrickValue;

    public AudioSource scoreSound;

    private GameManager gm;

	// Use this for initialization
	void Start () {
        gm = FindObjectOfType<GameManager>();
 	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void DestroyBrick()
    {

        GameObject scoreObject = (GameObject)Instantiate(scoreEffect, transform.position, transform.rotation);
        scoreObject.GetComponent<ScoreEffect>().scoreText.text = ""+BrickValue;
        gm.AddScore(BrickValue);
        scoreSound.Play();
        Destroy(gameObject);

    }
}
