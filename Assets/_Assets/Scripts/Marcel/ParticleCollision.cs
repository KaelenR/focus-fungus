using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticleCollision : MonoBehaviour
{
    public GameObject spawnGO;

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

        //Rigidbody rb = other.GetComponent<Rigidbody>();
        int i = 0;

        while (i < numCollisionEvents)
        {
            //if (rb)
            //{
                Vector3 pos = collisionEvents[i].intersection;
            Vector3 jiggly = new Vector3(Random.Range(-jiggleAmount, jiggleAmount), Random.Range(0, 360), Random.Range(-jiggleAmount, jiggleAmount));
            //Debug.Log(collisionEvents[i].normal + " " + jiggly);
                Quaternion norm = Quaternion.Euler(jiggly);
     

            //Vector3 giggle = new Vector3();

                GameObject.Instantiate(spawnGO, pos, norm);
                //Vector3 force = collisionEvents[i].velocity * 10;
                //rb.AddForce(force);
            //}
            i++;
        }
    }
}