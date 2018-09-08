using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_control : MonoBehaviour {

    private bool movingLeft;
    private bool movingRight;

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
    }

    public void startLeft()
    {
        movingLeft = true;
        Debug.Log("start Left");
    }

    public void stopLeft()
    {
        movingLeft = false;
        Debug.Log("stop Left");
    }

    public void startRight()
    {
        movingRight = true;
        Debug.Log("start Right");
    }

    public void stopRight()
    {
        movingRight = false;
        Debug.Log("stop Right");
    }
}
