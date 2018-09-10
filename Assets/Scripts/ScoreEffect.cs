using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreEffect : MonoBehaviour {

    public Text scoreText;

    private float lifetime = 2f;  //score effect duration

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        lifetime -= Time.deltaTime;

            if(lifetime < 0)
        {
            Destroy(gameObject);
        }
		
	}
}
