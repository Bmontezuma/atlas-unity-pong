using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;
    public float speed = 10f;
    public float boundaryY = 250f; // Adjust this value based on your game area's size

    void Update()
    {
        Vector3 position = transform.position;

        if (Input.GetKey(upKey))
        {
            position.y += speed * Time.deltaTime;
        }
        else if (Input.GetKey(downKey))
        {
            position.y -= speed * Time.deltaTime;
        }

        position.y = Mathf.Clamp(position.y, -boundaryY, boundaryY);
        transform.position = position;
    }
}
