using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float initialForce = 500f; // Increased the initial force for a noticeable start
    public float constantSpeed = 10f;

    private Rigidbody2D rb;
    private Vector2 initialDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Ensure the Rigidbody2D has the correct settings
        rb.gravityScale = 0;
        rb.angularDrag = 10f; // Prevent unwanted rotation
        rb.drag = 0; // No linear drag for consistent speed

        LaunchBall();
    }

    void LaunchBall()
    {
        // Log the launch to help with debugging
        Debug.Log("Launching Ball");

        // Choose a random initial direction
        initialDirection = Random.Range(0, 2) == 0 ? Vector2.right : Vector2.left;

        // Apply an initial force
        rb.AddForce(initialDirection * initialForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Paddle"))
        {
            Vector2 newVelocity = rb.velocity.normalized * constantSpeed;
            rb.velocity = newVelocity;
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