using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBase : MonoBehaviour
{
    private Transform gardenTransform;
    private Zombie zombie;
    public int startHealth { get { return 200; } }
    public int damage { get { return 100; } }
    protected int health;
    protected float speed { get { return 0.5f; } }
    protected int damageSpeed { get { return 60; } } 

    void Start()
    {
        health = startHealth;
        gardenTransform = GameObject.FindGameObjectWithTag("Garden").transform;
        Debug.Log(gardenTransform);

        GetComponent<Transform>().position =
            new Vector3(gardenTransform.position.x + 20, 0.95f, gardenTransform.position.z + (zombie.lane * 2) - 2);
    }

    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(-(speed * Time.smoothDeltaTime), 0, 0), ForceMode.Impulse);
    }

    public void Initialise(Zombie zombie)
    {
        this.zombie = zombie;
        
    }

    public void HitZombie(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        // TODO implement once we have a plant base
    }

}
