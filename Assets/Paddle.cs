using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Math;


public class Paddle : MonoBehaviour
{
    public bool isPlayer1;
    public float speed;
    public Rigidbody2D rb;

    public float maxBounceAngl = 55f;
    private float movement;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayer1)
        {
            movement = Input.GetAxisRaw("Vertical1");
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical2");
        }

        rb.velocity = new Vector2(movement * speed, rb.velocity.y);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        Ball ball = collision.gameObject.GetComponent<Ball>();
       
        if (ball != null)
        {
            float currAngle = Vector2.SignedAngle(Vector2.up, ball.GetComponent<Rigidbody2D>().velocity);
            float bounceAng = (transform.position.x - collision.GetContact(0).point.x / collision.otherCollider.bounds.size.x / 2) * maxBounceAngl;
            float newAngle = Mathf.Clamp(currAngle + bounceAng, -maxBounceAngl, maxBounceAngl);

            Quaternion rotation = Quaternion.AngleAxis(newAngle, Vector3.forward);
            ball.GetComponent<Rigidbody2D>().velocity = rotation * Vector2.up * ball.GetComponent<Rigidbody2D>().velocity.magnitude;


        }

    }
}
