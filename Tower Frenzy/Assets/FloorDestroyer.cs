using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorDestroyer : MonoBehaviour
{
    float timer;
    public float DestructionTime;

    void Start()
    {
        timer = 0.0f;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        timer += Time.fixedDeltaTime;

        if (timer >= DestructionTime && collision.gameObject.CompareTag("Walls"))
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        timer = 0.0f;
        Debug.Log("challas");
    }
}
