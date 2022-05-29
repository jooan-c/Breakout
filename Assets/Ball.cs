using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Random;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public bool isPlayer1;
    private float collisionPaddleSide;
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
        float x = .20F;
        float y = -1;
        float startX = NewFloat(-randVariance, randVariance);
        float startY = NewFloat(-randVariance, randVariance);
        rb.velocity = new Vector2(speed * (x + startX), speed * (y + startY));
    }


    // citation: https://www.codegrepper.com/code-examples/csharp/c%23+random+float+between+two+numbers
    static float NewFloat(float minVar, float maxVar)
    {
        System.Random rand = new System.Random();
        double val = (rand.NextDouble() * (maxVar - minVar) + minVar);
        return (float)val;
    }
}
