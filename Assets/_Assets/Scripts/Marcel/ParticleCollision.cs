using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticleCollision : MonoBehaviour
{
    public List<GameObject> spawnGOs;

    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;
    public float jiggleAmount = 14f;

    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void OnParticleCollision(GameObject other)
    {
        int numCollisionEvents = part.GetCollisionEvents(other, collisionEvents);

        int i = 0;
        while (i < numCollisionEvents)
        {
            Vector3 pos = collisionEvents[i].intersection;
            Vector3 jiggly = new Vector3(Random.Range(-jiggleAmount, jiggleAmount), Random.Range(0, 360), Random.Range(-jiggleAmount, jiggleAmount));
            Quaternion norm = Quaternion.Euler(jiggly);
            GameObject.Instantiate(spawnGOs[Random.Range(0, spawnGOs.Count)], pos, norm);
            i++;
        }

    }
}