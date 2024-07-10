using System.Collections;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float initialForce = 10f; // Adjust the initial force to your liking
    public float ballSpeed = 5f; // Maintain a constant speed throughout the game
    public float accelerationRate = 0.1f; // Rate at which the ball's speed increases
    public float maxSpeed = 20f; // Maximum speed the ball can reach

    private Rigidbody2D rb;
    private AudioSource audioSource;
    private Vector2 initialDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        LaunchBall();
    }

    /* Launches the ball in a random direction with an initial force. */
    void LaunchBall()
    {
        initialDirection = new Vector2(Random.Range(-1f, 1f), 1f).normalized;
        rb.AddForce(initialDirection * initialForce, ForceMode2D.Impulse);
    }

    /* Handles collision events. Reflects the ball's velocity and adjusts its speed. */
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 collisionNormal = collision.contacts[0].normal;
        rb.velocity = Vector2.Reflect(rb.velocity, collisionNormal);
        AdjustSpeed();
        PlayImpactSound();
    }

    /* Ensures the ball maintains a constant speed after collisions. */
    void AdjustSpeed()
    {
        float speed = ballSpeed;
        rb.velocity = rb.velocity.normalized * speed;
    }

    /* Plays a sound effect when the ball collides with an object. */
    void PlayImpactSound()
    {
        audioSource.pitch = Random.Range(0.8f, 1.2f);
        audioSource.Play();
    }

    /* Resets the ball's position and velocity after scoring. */
    public void ResetBall()
    {
        transform.position = Vector2.zero;
        rb.velocity = Vector2.zero;
        LaunchBall();
    }

    void Update()
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.velocity *= (1 + accelerationRate * Time.deltaTime);
        }
    }
}
