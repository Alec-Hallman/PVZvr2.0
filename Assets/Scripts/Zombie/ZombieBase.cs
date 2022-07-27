using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBase : MonoBehaviour
{
    private Transform gardenTransform;
    private Zombie zombie;
    public float startHealth;
    public int damage { get { return 100; } }
    protected float health;
    protected float speed { get { return 0.45f; } }
    protected int damageSpeed { get { return 1; } }
    protected float startTime;
    protected GameObject currentlyEating;

    void Start()
    {
        health = startHealth;
        gardenTransform = GameObject.FindGameObjectWithTag("Garden").transform;
        currentlyEating = null;

        GetComponent<Transform>().position =
            new Vector3(gardenTransform.position.x + 20, 1.45f, gardenTransform.position.z + (zombie.lane * 2) - 2);
            new Vector3(gardenTransform.position.x + 20, 1.45f, gardenTransform.position.z + (zombie.lane * 2) - 2);
    }

    void Update()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(-(speed * Time.smoothDeltaTime * 10), 0, 0), ForceMode.Impulse);

        if(currentlyEating != null && Time.realtimeSinceStartup - startTime > damageSpeed)
        {
            Eat();
            startTime = Time.realtimeSinceStartup;
        }
    }

    public void Initialise(Zombie zombie)
    {
        this.zombie = zombie;
        
    }

    public void HitZombie(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(string.Format("Zombie Collided! {0}", collision.collider.gameObject.tag));
        if (collision.collider.gameObject.tag == "Plant")
        {
            currentlyEating = collision.collider.gameObject;
            startTime = Time.realtimeSinceStartup;
        }
  
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject == currentlyEating)
        {
            currentlyEating = null;
        }
    }

    private void Eat()
    {
        currentlyEating.GetComponent<PlantBase>().TakeDamage(damage);
    }

}
