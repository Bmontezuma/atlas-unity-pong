using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float initialForce = 500f;
    public float constantSpeed = 10f;
    public float maxBounceAngle = 75f; // Maximum angle at which the ball can bounce off

    private Rigidbody2D rb;
    private Vector2 initialDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        LaunchBall();
    }

    void LaunchBall()
    {
        initialDirection = Random.Range(0, 2) == 0 ? Vector2.right : Vector2.left;
        rb.AddForce(initialDirection * initialForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            Vector2 paddlePosition = collision.transform.position;
            float hitPoint = transform.position.y - paddlePosition.y;
            float paddleHeight = collision.collider.bounds.size.y;
            float bounceAngle = (hitPoint / paddleHeight) * maxBounceAngle;

            Vector2 bounceDirection = new Vector2(
                rb.velocity.x > 0 ? 1 : -1,
                Mathf.Tan(bounceAngle * Mathf.Deg2Rad)
            ).normalized;

            rb.velocity = bounceDirection * constantSpeed;
        }
    }

    public void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        LaunchBall();
    }

    void FixedUpdate()
    {
        rb.velocity = rb.velocity.normalized * constantSpeed;
    }
}