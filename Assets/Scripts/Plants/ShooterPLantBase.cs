using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ShooterPLantBase : PLantBase
{
    private float startTime;
    public GameObject pea;
    void Start()
    {
        startTime = Time.realtimeSinceStartup;
    }

    void Update()
    {
        float currentTime = Time.realtimeSinceStartup - startTime;
        Rigidbody rb = GetComponent<Rigidbody>();
        if (currentTime > damageSpeed)
        {
            startTime = Time.realtimeSinceStartup;
            Shoot();
        }
    }
    public void Shoot()
    {
        pea = Instantiate(pea);
        pea.transform.position = transform.position;
        Debug.Log(PrefabUtility.GetCorrespondingObjectFromSource(gameObject));
        //Trying to get the name of the Peashooter to position the projectile properly
       // pea.GetComponent<Projectile>().Spawn(PrefabUtility.GetCorrespondingObjectFromSource(gameObject));
    }

}
