using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPlantBase : PlantBase
{
    private float chewTime = 42f;
    private float startTime;
    private string name;
    private bool Chewing = false;
    public float damage;
    // Start is called before the first frame update
    void Start()
    {

        startTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health);
        if (Chewing == true)
        {
            gameObject.GetComponent<SphereCollider>().enabled = true; //enable sphere collider
            float currentTime = Time.realtimeSinceStartup - startTime;
            if (currentTime > chewTime)
            {
                Chewing = false;
            }
            Debug.Log(currentTime);

        }
        else //if chewing is false
        {
            gameObject.GetComponent<SphereCollider>().enabled = false; // disable sphere collider\
            //hey bro (if you read this) So this sphere makes it so that the zombie collides with the sphere and not the cube. So essentially the next zombie hits the sphere if the chomper is chewing
            //and if the chomper finishes before it dies the zombie will walk a very small ammount re colliding with the chomper and dying.
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie" && Chewing == false)
        {
            collision.gameObject.GetComponent<ZombieBase>().HitZombie(damage);
            Chewing = true;
            Start();
            //Destroy(gameObject); This is needed if its a squash
        }
    }
}
