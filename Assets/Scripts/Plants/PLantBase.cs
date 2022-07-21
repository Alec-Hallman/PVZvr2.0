using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Shooter Plant Base
public class PLantBase : MonoBehaviour
{
    public int startHealth { get { return 0; } }
    public int damage { get { return 0; } }
    protected int health;
    protected float damageSpeed { get { return 1.5f; } }

    void Start()
    {

        health = startHealth;
    }



    public void HitPlant(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
