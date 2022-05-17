using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Random;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public bool isPlayer1;
    private int collisionPaddleSegment;
    float startX;
    float startY;
    float randVariance = .15f;


    // Start is called before the first frame update
    void Start()
    {
        InitiateGame();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void InitiateGame()
    {
        if (isPlayer1)
        {
            transform.position = new Vector2(5, -2);
        }
        else
        {
            transform.position = new Vector2(-5, -2);
        }
        float x = .75F;
        float y = -1;
        startX = NextFloat(-randVariance, randVariance);
        startY = NextFloat(-randVariance, randVariance);
        //print(startX);
        //print(startY);
        rb.velocity = new Vector2(speed * (x + startX), speed * (y + startY));
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.name == "Player1Paddle" || collision.collider.name == "Player2Paddle")
        {

            // this gets the method we need from PaddleController
            GameObject go = GameObject.Find("Player1Paddle");
            Paddle paddleController = (Paddle)go.GetComponent(typeof(Paddle));

            //this gets which part (segment, 1-5) of the paddle the ball hit
            collisionPaddleSegment = paddleController.getCollisionSegment();
            //print(collisionPaddleSegment);
            /*  if (switchDirectionCheck())
              {
                 // print("switch!!!!");
                  // reverse direction
                  Vector2 tempBallVelocity = new Vector2(rb.velocity.x * -1, rb.velocity.y);
                  rb.velocity = tempBallVelocity;
              }
              */

            // print("rb.velocity is" + rb.velocity);

        }
    }

    // citation: https://www.codegrepper.com/code-examples/csharp/c%23+random+float+between+two+numbers
    static float NextFloat(float min, float max)
    {
        System.Random random = new System.Random();
        double val = (random.NextDouble() * (max - min) + min);
        return (float)val;
    }

    bool switchDirectionCheck()
    {
        print("collisionPaddleSegment is" + collisionPaddleSegment);
        // check to see if we should change the ball's direction
        if (collisionPaddleSegment == 0 && (rb.velocity.x > 0))
        {
            return true;
        }
        if (collisionPaddleSegment == 1 && (rb.velocity.x < 0))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
