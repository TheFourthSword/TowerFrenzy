using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjects : MonoBehaviour
{

    public Transform grabPoint;
    public Transform rayPoint;
    public float rayDistance;

    private GameObject grabbedObject;
    private int layerIndex;
    // Start is called before the first frame update
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
        //Rigidbody2D.useFullKinematicContacts;
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        if (hitInfo.collider!=null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            if (Input.GetKeyDown(KeyCode.Space) && grabbedObject == null)
            {
                //grabbedObject.GetComponent<boxPoof>().StopAllCoroutines();
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = false;
                grabbedObject.GetComponent<BoxCollider2D>().enabled = true;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);
            }

            else if (Input.GetKeyDown(KeyCode.Space))
            {
                grabbedObject.GetComponent<Rigidbody2D>().isKinematic = true;
                grabbedObject.GetComponent<BoxCollider2D>().enabled = false;
                grabbedObject.transform.SetParent(null);
                //grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                grabbedObject = null;

            }
        }

        Debug.DrawRay(rayPoint.position, transform.right * rayDistance);
    }
}
