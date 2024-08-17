using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjectsTwo : MonoBehaviour
{

    public Transform grabPoint;
    public Transform rayPoint;
    public float rayDistance;

    private GameObject grabbedObject2;
    private int layerIndex;
    // Start is called before the first frame update
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        if (Input.GetKeyDown(KeyCode.KeypadEnter) && grabbedObject2)
        {
           // grabbedObject2.GetComponent<boxPoof>().StopAllCoroutines();
            Debug.Log("2");
            grabbedObject2.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbedObject2.GetComponent<BoxCollider2D>().enabled = true;
            grabbedObject2.transform.SetParent(null);
            //grabbedObject2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            grabbedObject2 = null;

        }

        if (hitInfo.collider!=null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            if (Input.GetKeyDown(KeyCode.KeypadEnter) && grabbedObject2 == null)
            {
                Debug.Log("1");
                grabbedObject2 = hitInfo.collider.gameObject;
                grabbedObject2.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject2.GetComponent<BoxCollider2D>().enabled = false;
                grabbedObject2.transform.position = grabPoint.position;
                grabbedObject2.transform.SetParent(transform);
            }

           
        }
       

        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
    }
}
