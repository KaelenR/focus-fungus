using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Script scales up a gameObject up over a period of time and if it exists pitch bends up audio. 
/// After that time ends we set max scale, delete the audioSource and this script
/// </summary>
public class ScaleOnStart : MonoBehaviour
{
    public float minScale = 0.01f;
    public float maxScale = 1f;

    public float scaleVariability = 0.2f;

    public float endTime = 1f;
    float _currentTime;

    public AudioSource aSource;

    void Start()
    {
        transform.localScale = Vector3.one * minScale;
        maxScale += Random.Range(0, maxScale * scaleVariability);

        if(aSource && aSource.clip)
            aSource.Play();
    }

    void Update()
    {
        _currentTime += Time.deltaTime;

        if(_currentTime > endTime)
        {
            transform.localScale = Vector3.one * maxScale;

            if(aSource && aSource.clip)
                Destroy(aSource);

            Destroy(this);
        }

        var currentMultiplier = (maxScale - minScale) * (_currentTime / endTime);
        transform.localScale = Vector3.one * currentMultiplier;
        aSource.pitch = currentMultiplier;
    }
}
