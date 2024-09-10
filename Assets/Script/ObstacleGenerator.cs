using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{
    public GameObject cabbagePrefab;
    public GameObject paperPrefab;
    public GameObject dogPrefab;
    float span = 1.0f;
    float delta = 0;
    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject go;
            int randomValue = Random.Range(0, 3);
           
            if (randomValue == 0)
            {
                go = Instantiate(cabbagePrefab);
                int px = Random.Range(-3, 3);
                go.transform.position = new Vector3(-12, px, 0);
            }
            else if (randomValue == 1)
            {
                go = Instantiate(paperPrefab);
                int px = Random.Range(-3, 3);
                go.transform.position = new Vector3(-12, px, 0);
            }
            else
            {
                go = Instantiate(dogPrefab);
                go.transform.position = new Vector3(-13, -2, 0);
            }
            
        }
    }
}
