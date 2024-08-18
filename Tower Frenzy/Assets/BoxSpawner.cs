using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] boxPrefab;
    [SerializeField] float secondSpawn = 0.5f;
    [SerializeField] float minTras;
    [SerializeField] float maxTras;

    public static bool playing = true;
    void Start()
    {
        if (playing)
        {
            StartCoroutine(BoxSpawned());
        }
         
    }

    IEnumerator BoxSpawned()
    {
        while(true)
        {
            var wanted = Random.Range(minTras, maxTras);
            var position = new Vector3(wanted, transform.position.y);
            GameObject gameObject = Instantiate(boxPrefab[Random.Range(0, boxPrefab.Length)],
                position, Quaternion.identity);
            yield return new WaitForSeconds(secondSpawn);

            if (!playing)
            {
                break;
            }
           
        }
    }


}
