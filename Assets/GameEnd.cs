using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public bool isPlayer1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<Ball>().InitiateGame();
        if (isPlayer1)
        {
            FindObjectOfType<BrickManagerPlayer1>().ResetLevel();
        }
        else
        {
            FindObjectOfType<BrickManagerPlayer2>().ResetLevel();
        }
    }
}
