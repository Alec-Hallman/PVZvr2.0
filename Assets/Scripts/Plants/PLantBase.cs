using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Shooter Plant Base
public class PlantBase : MonoBehaviour
{
    public int startHealth;
    public int damage { get { return 0; } }
    protected int health;
    public float damageSpeed;

    void Start()
    {
        health = startHealth;
    }



    public void TakeDamage(int damage)
    {
       // Debug.Log("Ouch!");
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
