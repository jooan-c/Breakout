using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        InitiateGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void InitiateGame()
    {
        float x = 0.75F;
        float y = -1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }
}
