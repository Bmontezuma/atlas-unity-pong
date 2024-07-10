using UnityEngine;

public class AIPlayer : MonoBehaviour
{
    private Paddle paddle;
    public Transform ball;
    public float reactionSpeed = 5f;

    void Start()
    {
        paddle = GetComponent<Paddle>();
        Player player = GetComponent<Player>();
        if (player != null)
        {
            player.enabled = false;
        }
    }

    void Update()
    {
        Vector2 direction = Vector2.zero;
        if (ball.position.y > transform.position.y)
        {
            direction = Vector2.up;
        }
        else if (ball.position.y < transform.position.y)
        {
            direction = Vector2.down;
        }
        paddle.Move(direction);
    }
}
