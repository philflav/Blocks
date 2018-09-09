using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public float maxVBallSpeed; //speed limit
    public float maxHBallSpeed; //speed limit

    public float VSpeed;

    private Rigidbody2D rb;

    public bool ballActive;

    public Transform startPoint;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(maxHBallSpeed,VSpeed);


		
	}

    // Update is called once per frame
    void Update()
    {
        if (!ballActive)
        {
            rb.velocity = Vector2.zero;
            rb.position = startPoint.position;
                
        }
        
        
        
        //limit horizontal ball speed
        if (rb.velocity.x > maxHBallSpeed)
        {
            rb.velocity = new Vector2(maxHBallSpeed, rb.velocity.y);

        }
        if (rb.velocity.x < -maxHBallSpeed)
        {
            rb.velocity = new Vector2(-maxHBallSpeed, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
    
       

    }

    public void activateBall()
    {
        ballActive = true;
        rb.velocity = new Vector2(VSpeed, VSpeed);
    }

  



}
