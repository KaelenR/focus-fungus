using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This Script has a public function allowing us to set the emission of a particle system with an event in editor
/// </summary>
public class ParticleRemote : MonoBehaviour
{
    public float baseEmission = 0.05f;
    public float maxEmission = 0.5f;

    public ParticleSystem pSystem;

    public void SetEmission(float value)
    {
        ParticleSystem.EmissionModule e = pSystem.emission;
        e.rateOverTimeMultiplier = value == -1 ? baseEmission : Mathf.Lerp(baseEmission, maxEmission, value);
    }

}
