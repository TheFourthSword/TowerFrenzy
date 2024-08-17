using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxPoof : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Walls")
        {

            StartCoroutine(KillBox());
        }
        else
        {
            StopCoroutine(KillBox());
        }

    }

   // private void OnCollisionExit2D(Collision2D collision)
  //  {

      //  if (collision.gameObject.tag == "Walls")
       // {
       //     Debug.Log("Je Moeder");
       //     StopCoroutine(KillBox());

       // }
  //  }

    IEnumerator KillBox()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
