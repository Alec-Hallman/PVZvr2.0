using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private float currentTime = 0;
    private bool animating;
    private float startTime;
    public float damage;
    void Start()
    {
        animating = false;
        GetComponent<ParticleSystem>().Stop();
        startTime = Time.realtimeSinceStartup;
    }
    void FixedUpdate()
    {
        if(animating == true)
        {
            currentTime = currentTime + 0.04f;
            if (currentTime > 0.9f)
            {
               Destroy(gameObject);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        var particleSystem = gameObject.GetComponent<ParticleSystem>();
        if (collision.gameObject.tag == "Zombie")
        {
            animating = true;
            particleSystem.Play();
            collision.gameObject.GetComponent<ZombieBase>().HitZombie(damage);

            Destroy(gameObject.GetComponent<Renderer>());
            Destroy(gameObject.GetComponent<SphereCollider>());

        }
    }

}
