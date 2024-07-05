using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode upKey = KeyCode.W;
    public KeyCode downKey = KeyCode.S;

    private Paddle paddle;

    void Start()
    {
        paddle = GetComponent<Paddle>();
    }

    void Update()
    {
        if (Input.GetKey(upKey))
        {
            paddle.MoveUp();
        }
        if (Input.GetKey(downKey))
        {
            paddle.MoveDown();
        }
    }
}
