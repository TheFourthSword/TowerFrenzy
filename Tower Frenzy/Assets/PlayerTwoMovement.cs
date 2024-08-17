using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoMovement : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;


    // Start is called before the first frame update
    private void Start()
    {
        Time.timeScale = 1f;
        rb = GetComponent<Rigidbody2D>();


    }

    private void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {

        Vector2 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            movement = Vector2.up;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movement = Vector2.left;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            movement = Vector2.down;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            movement = Vector2.right;
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.KeypadEnter))
        {

        }
    }
}
