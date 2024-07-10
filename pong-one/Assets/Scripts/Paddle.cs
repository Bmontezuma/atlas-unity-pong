using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    public void Move(Vector2 direction)
    {
        float newYPosition = Mathf.Clamp(transform.position.y + direction.y * speed * Time.deltaTime, -200f, 200f);
        transform.position = new Vector3(startPosition.x, newYPosition, startPosition.z);
    }

    public void MoveUp()
    {
        float newYPosition = Mathf.Clamp(transform.position.y + speed * Time.deltaTime, -200f, 200f);
        transform.position = new Vector3(startPosition.x, newYPosition, startPosition.z);
    }

    public void MoveDown()
    {
        float newYPosition = Mathf.Clamp(transform.position.y - speed * Time.deltaTime, -200f, 200f);
        transform.position = new Vector3(startPosition.x, newYPosition, startPosition.z);
    }
}
