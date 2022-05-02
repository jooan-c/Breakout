using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public bool isPlayer1;
    
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
        float x = 0.75F;
        float y = -1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }
}
