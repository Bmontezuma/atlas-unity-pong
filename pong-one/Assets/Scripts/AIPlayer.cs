using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    private Paddle paddle;
    public DifficultyLevel difficulty = DifficultyLevel.Medium;

    public enum DifficultyLevel
    {
        Easy,
        Medium,
        Hard
    }

    void Start()
    {
        // Search for the Paddle component in the parent object
        paddle = GetComponentInParent<Paddle>();

        // If a Player component is present in the parent object, deactivate it
        Player player = GetComponentInParent<Player>();
        if (player != null)
        {
            player.enabled = false;
        }
    }

    void Update()
    {
        if (paddle != null)
        {
            // Implement AI logic here
            // Example: Move the paddle based on the ball's position
            GameObject ball = GameObject.FindGameObjectWithTag("Ball");
            if (ball != null)
            {
                float ballPositionY = ball.transform.position.y;
                MoveAI(ballPositionY);
            }
        }
    }

    void MoveAI(float ballPositionY)
    {
        float targetPositionY = ballPositionY;

        switch (difficulty)
        {
            case DifficultyLevel.Easy:
                targetPositionY += Random.Range(-1f, 1f); // Add some error
                paddle.speed = 5f; // Slower speed
                break;
            case DifficultyLevel.Medium:
                targetPositionY += Random.Range(-0.5f, 0.5f); // Less error
                paddle.speed = 10f; // Normal speed
                break;
            case DifficultyLevel.Hard:
                targetPositionY += Random.Range(-0.2f, 0.2f); // Minimal error
                paddle.speed = 15f; // Faster speed
                break;
        }

        paddle.MovePaddle(targetPositionY);
    }
}
