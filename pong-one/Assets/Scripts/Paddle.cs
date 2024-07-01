using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10f;
    public float boundaryY = 300f; // Adjust this value based on your game's playable area

    void Update()
    {
        Vector3 position = transform.localPosition;

        if (position.y > boundaryY)
        {
            position.y = boundaryY;
        }
        if (position.y < -boundaryY)
        {
            position.y = -boundaryY;
        }

        transform.localPosition = position;
    }

    public void MoveUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public void MoveDown()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}