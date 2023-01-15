using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleOnStart : MonoBehaviour
{

    public float minScale = 0.01f;
    public float maxScale = 1f;

    public float scaleVariability = 0.2f;

    public float endTime = 1f;

    float _currentTime;

    public AudioSource aSource;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.one * minScale;
        maxScale += Random.Range(0, maxScale * scaleVariability);
        aSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        _currentTime += Time.deltaTime;
        if(_currentTime > endTime)
        {
            transform.localScale = Vector3.one * maxScale;
            Destroy(aSource);
            Destroy(this);
        }

        transform.localScale = Vector3.one * (maxScale - minScale) * (_currentTime / endTime);
        aSource.pitch = transform.localScale.x;



    }
}
