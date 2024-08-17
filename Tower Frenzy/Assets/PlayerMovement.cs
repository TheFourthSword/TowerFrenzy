using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;
    Rigidbody2D rb;
    bool isHolding = false;
    bool canGrab;

    

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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "grabby" && isHolding == false)
        {

        }
    }

    void HandleInput()
    {

        Vector2 movement = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            movement = Vector2.up;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movement = Vector2.left;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movement = Vector2.down;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movement = Vector2.right;
        }

        rb.MovePosition(rb.position + movement * moveSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && isHolding)
        {
            isHolding = true;
        }
    }
}
