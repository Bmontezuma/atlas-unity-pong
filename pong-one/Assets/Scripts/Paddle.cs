using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10f;

    public void MoveUp()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    public void MoveDown()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}