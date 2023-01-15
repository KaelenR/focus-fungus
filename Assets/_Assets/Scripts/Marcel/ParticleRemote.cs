using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRemote : MonoBehaviour
{
    public float baseEmission = 0.05f;
    public float maxEmission = 0.5f;
    //public float emissionMultiplier = 1f;

    // public float baseSpread = .27f;
    // public float spreadMultiplier = 1f;

    public ParticleSystem pSystem;

    /*public void Update()
    {
        SetEmission(.5f);
        SetSpread(.5f);
    }*/

    public void SetEmission(float value)
    {
        ParticleSystem.EmissionModule e = pSystem.emission;
        //float adjVal = value == -1 ? 0.1f : Mathf.Lerp(0.1f, 1, value);
        e.rateOverTimeMultiplier = value == -1 ? baseEmission : Mathf.Lerp(baseEmission, maxEmission, value);
    }

    /*public void SetSpread(float value)
    {
        ParticleSystem.ShapeModule s = pSystem.shape;
        float adjVal = value == -1 ? 0.05f : Mathf.Lerp(0.01f, 1, value);
        s.radius = baseSpread * adjVal * spreadMultiplier;

    }*/
}
