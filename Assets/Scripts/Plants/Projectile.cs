using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Zombie")
        {
            collision.gameObject.GetComponent<ZombieBase>().HitZombie(damage);
            Destroy(gameObject);
            if (gameObject.tag == "slow")
            {
                Debug.Log("Frozen");
                collision.gameObject.GetComponent<Rigidbody>().mass = 20;
            }
        }
    }
}
