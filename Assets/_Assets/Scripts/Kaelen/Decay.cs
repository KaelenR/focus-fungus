using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decay : MonoBehaviour
{

    public float maxTimer = 10.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        maxTimer -= Time.deltaTime;

        if(maxTimer <= 0.0f)
        {
            Destroy(gameObject);
        }


    }
}
