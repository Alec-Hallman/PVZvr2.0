using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instant_Base : PlantBase1
{
    public GameObject particles;
    public int damage;
    protected float startTime;
    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        startTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.realtimeSinceStartup - startTime;
 
        if (currentTime > 0.95f)
        {
            GetComponent<BoxCollider>().enabled = true;
        }
        if (currentTime > 1f)
        {
            GameObject boomBoom = Instantiate(particles);
            boomBoom.transform.position = transform.position;
            Destroy(gameObject);

        }
    }
    void OnTriggerEnter(Collider collision)
    {
        collision.gameObject.GetComponent<ZombieBase>().HitZombie(damage);
    }
}
