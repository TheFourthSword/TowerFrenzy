using UnityEngine;

public class Draggable2D : MonoBehaviour
{
    private Vector3 offset;
    private bool isDragging = false;

    void OnMouseDown()
    {
        // Calculate the offset between mouse world position and object position
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offset = transform.position - new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z);
        isDragging = true;
    }

    void OnMouseDrag()
    {
        if (isDragging)
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mouseWorldPos.x, mouseWorldPos.y, transform.position.z) + offset;
        }
    }

    void OnMouseUp()
    {
        isDragging = false;
    }
}

