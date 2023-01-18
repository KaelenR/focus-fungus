using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script kills this gameObject maxTimer seconds after start
/// </summary>
public class Decay : MonoBehaviour
{

    public float maxTimer = 10.0f;

    void Update()
    {
        maxTimer -= Time.deltaTime;

        if(maxTimer <= 0.0f)
        {
            Destroy(gameObject);
        }


    }
}
