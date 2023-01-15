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
        ParticleSystem.EmissionModule e = pSystem.emission;
        e.rateOverTimeMultiplier = baseEmission * Mathf.Lerp(0.1f, 1, value) *emissionMultiplier;
    }

    public void SetSpread(float value)
    {
        ParticleSystem.ShapeModule s = pSystem.shape;
        s.radius = baseSpread * Mathf.Lerp(0.1f, 1, value) * spreadMultiplier;

    }
}
