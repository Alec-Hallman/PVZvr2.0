using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlantBase : PlantBase
{
    Vector3 startPosition;
    Vector3 endPosition;
    public string Names;
    private float chargeTime = 15f;
    private bool charged;
    private float chewTime = 42f;
    private float startTime;
    private bool Chewing = false;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<ParticleSystem>().Stop();
        startPosition = new Vector3(0.27f, 0.4f, 0f);
        endPosition = new Vector3(0.27f, 0.6f, 0f);
        charged = false;
        health = startHealth;
        startTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Names);
        if (Names.Contains("Mine"))
        {
            if (charged == false)
            {
                transform.localPosition = new Vector3(0.27f, 0.4f, 0f);
                float currentTime = Time.realtimeSinceStartup - startTime;
                if (chargeTime < currentTime)
                {
                    charged = true;
                    startTime = Time.realtimeSinceStartup;
                }
            }
            else
            {
                GetComponent<BoxCollider>().enabled = false;
                float newTime = Time.realtimeSinceStartup - startTime;
                if (newTime < 1f)
                {
                    GetComponent<ParticleSystem>().Play();
                    transform.localPosition = Vector3.Slerp(startPosition, endPosition, newTime); 
                }
                else
                {
                 GetComponent<ParticleSystem>().Stop();
                }

            }
        }

        if (Names.Contains("Chomp"))
        {
            if (Chewing == true)
            {
                gameObject.GetComponent<SphereCollider>().enabled = true; //enable sphere collider
                float currentTime = Time.realtimeSinceStartup - startTime;
                if (currentTime > chewTime)
                {
                    Chewing = false;
                }


            }
            else //if chewing is false
            {
                gameObject.GetComponent<SphereCollider>().enabled = false; // disable sphere collider\
              //hey bro So this sphere makes it so that the zombie collides with the sphere and not the cube. So essentially the next zombie hits the sphere if the chomper is chewing
              //and if the chomper finishes before it dies the zombie will walk a very small ammount re colliding with the chomper and dying.
            }
        }

    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie" && Chewing == false && Names.Contains("Chomp"))
        {
            collision.gameObject.GetComponent<ZombieBase>().HitZombie(damage);
            Chewing = true;
            Start();


        }
        if (charged == true && Names.Contains("Mine"))
        {
            collision.gameObject.GetComponent<ZombieBase>().HitZombie(damage);
            Destroy(gameObject);
        }
    }
}
