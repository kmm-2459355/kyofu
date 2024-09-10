using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperController : MonoBehaviour
{
    void Update()
    {
        transform.Translate(0.1f, 0, 0);
        if(transform.position.x > 15)
        {
            Destroy(gameObject);
        }
    }
}
