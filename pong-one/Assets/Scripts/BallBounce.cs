using System.Collections;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public float startSpeed = 5f;
    public float extraSpeed = 0.5f;
    public float maxSpeed = 10f;

    private int hitCounter = 0;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }

    public IEnumerator Launch()
    {
        hitCounter = 0;
        yield return new WaitForSeconds(1);

        // Random initial direction
        Vector2 initialDirection = Random.Range(0, 2) == 0 ? Vector2.right : Vector2.left;
        MoveBall(initialDirection);
    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;
        float ballSpeed = startSpeed + (hitCounter * extraSpeed);
        ballSpeed = Mathf.Min(ballSpeed, maxSpeed); // Ensure the speed doesn't exceed maxSpeed
        rb.velocity = direction * ballSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            HandlePaddleCollision(collision);
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            // Handle wall collision if necessary
        }
    }

    void HandlePaddleCollision(Collision2D collision)
    {
        // Calculate the bounce angle based on collision point on the paddle
        Vector2 paddlePosition = collision.transform.position;
        float hitPoint = transform.position.y - paddlePosition.y;
        float paddleHeight = collision.collider.bounds.size.y;
        float bounceAngle = (hitPoint / paddleHeight) * 75f; // 75 degrees max angle

        // Determine the bounce direction based on the calculated angle
        Vector2 bounceDirection = new Vector2(
            rb.velocity.x > 0 ? -1 : 1,
            Mathf.Tan(bounceAngle * Mathf.Deg2Rad)
        ).normalized;

        hitCounter++;
        MoveBall(bounceDirection);
    }

    public void ResetBall()
    {
        rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        StartCoroutine(Launch());
    }
}
