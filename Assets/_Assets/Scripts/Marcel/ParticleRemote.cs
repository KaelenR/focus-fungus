using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRemote : MonoBehaviour
{
    public float baseEmission = 2f;
    public float emissionMultiplier = 1f;

    public float baseSpread = .27f;
    public float spreadMultiplier = 1f;

    public ParticleSystem pSystem;

    public void SetEmission(float value)
    {
        var e = pSystem.emission;
        e.rateOverTimeMultiplier = baseEmission * emissionMultiplier;
    }

    public void SetSpread(float value)
    {
        var s = pSystem.shape;
        s.radius = baseSpread * spreadMultiplier;

    }
}
