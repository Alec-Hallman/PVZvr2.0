using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{ 
    public float damage;
    void Start()
    {
        GetComponent<ParticleSystem>().Stop();

    }

    void OnCollisionEnter(Collision collision)
    {
        var particleSystem = gameObject.GetComponent<ParticleSystem>();
        if (collision.gameObject.tag == "Zombie")
        {
            particleSystem.Play();
            collision.gameObject.GetComponent<ZombieBase>().HitZombie(damage);
            if (gameObject.tag == "slow")
            {
                Debug.Log("Frozen");
                collision.gameObject.GetComponent<Rigidbody>().mass = 20;
            }
            Destroy(gameObject.GetComponent<Renderer>());
        }
    }

}
