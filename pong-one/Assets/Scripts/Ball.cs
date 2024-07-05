using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Public variables for initial force, constant speed, bounce angle, acceleration rate, and maximum speed
    public float initialForce = 500f;
    public float constantSpeed = 10f;
    public float maxBounceAngle = 75f; // Maximum angle at which the ball can bounce off
    public float accelerationRate = 0.1f; // Acceleration rate per second
    public float maxSpeed = 20f; // Maximum speed limit

    private Rigidbody2D rb;
    private Vector2 initialDirection;
    private AudioSource paddleAudioSource;
    private AudioSource wallAudioSource;

    void Start()
    {
        // Initialize Rigidbody2D component and AudioSources
        rb = GetComponent<Rigidbody2D>();
        AudioSource[] audioSources = GetComponents<AudioSource>();
        paddleAudioSource = audioSources[0];
        wallAudioSource = audioSources[1];
        LaunchBall(); // Launch the ball at the start of the game
    }

    void LaunchBall()
    {
        // Determine the initial direction of the ball randomly
        initialDirection = Random.Range(0, 2) == 0 ? Vector2.right : Vector2.left;
        // Apply initial force to the ball in the chosen direction
        rb.AddForce(initialDirection * initialForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check for collision with paddles
        if (collision.gameObject.CompareTag("Paddle"))
        {
            HandlePaddleCollision(collision); // Handle paddle collision logic
            PlayImpactSound(paddleAudioSource); // Play sound for paddle collision
        }
        // Check for collision with walls
        else if (collision.gameObject.CompareTag("Wall"))
        {
            PlayImpactSound(wallAudioSource); // Play sound for wall collision
        }
    }

    void HandlePaddleCollision(Collision2D collision)
    {
        // Calculate the bounce angle based on collision point on the paddle
        Vector2 paddlePosition = collision.transform.position;
        float hitPoint = transform.position.y - paddlePosition.y;
        float paddleHeight = collision.collider.bounds.size.y;
        float bounceAngle = (hitPoint / paddleHeight) * maxBounceAngle;

        // Determine the bounce direction based on the calculated angle
        Vector2 bounceDirection = new Vector2(
            rb.velocity.x > 0 ? 1 : -1,
            Mathf.Tan(bounceAngle * Mathf.Deg2Rad)
        ).normalized;

        // Set the ball's velocity to the new direction with constant speed
        rb.velocity = bounceDirection * constantSpeed;
    }

    void PlayImpactSound(AudioSource audioSource)
    {
        // Randomize the pitch of the sound for variety
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.Play(); // Play the sound
    }

    public void ResetBall()
    {
        // Reset the ball's position and velocity, and relaunch it
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        LaunchBall();
    }

    void FixedUpdate()
    {
        AccelerateBall(); // Gradually increase the ball's speed over time
        rb.velocity = rb.velocity.normalized * constantSpeed; // Maintain constant speed
    }

    void AccelerateBall()
    {
        // Increase the ball's speed based on the acceleration rate, up to the maximum speed
        constantSpeed += accelerationRate * Time.deltaTime;
        constantSpeed = Mathf.Min(constantSpeed, maxSpeed);
    }
}
