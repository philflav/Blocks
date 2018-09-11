using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_control : MonoBehaviour {

    private bool movingLeft;
    private bool movingRight;

    public Rigidbody2D leftLimit;
    public Rigidbody2D rightLimit;

    public BallController bc;

 


    public float paddle_speed;
    public int direction;

	// Use this for initialization
	void Start () {

 
		
	}
	
	// Update is called once per frame
	void Update () {
        if (movingLeft && !movingRight)
        {
            direction = -1;
        }
        else if (!movingLeft && movingRight)
        {
            direction = 1;
        }
        else
        {
            direction = 0;
        }

        //Debug.Log(direction);

        transform.Translate(direction * paddle_speed * Time.deltaTime, 0, 0);

        //Keep Paddle in bounds

        if (transform.position.x <= leftLimit.position.x)
        {
            transform.position = new Vector2(leftLimit.position.x, transform.position.y);
        }
        if (transform.position.x >= rightLimit.position.x)
        {
            transform.position = new Vector2(rightLimit.position.x, transform.position.y);
        }
    }

    public void startLeft()
    {
        movingLeft = true;
        //Debug.Log("start Left");
    }

    public void stopLeft()
    {
        movingLeft = false;
        //Debug.Log("stop Left");
        if(!bc.ballActive && movingRight)bc.activateBall();
    }

    public void startRight()
    {
        movingRight = true;
        //Debug.Log("start Right");
    }

    public void stopRight()
    {
        movingRight = false;
        // Debug.Log("stop Right");
        if (!bc.ballActive && movingLeft)bc.activateBall();
    }
}
