using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunPlant : PlantBase
{
    public GameObject sunPrefab;
    public int sunValue;
    public float sunSpeed;
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
        startTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.realtimeSinceStartup - startTime > sunSpeed)
        {
            startTime = Time.realtimeSinceStartup;
            // produce a sun
            GameObject newSun = Instantiate(sunPrefab);
            newSun.transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
            newSun.GetComponent<Rigidbody>().AddForce(Vector3.up * 3, ForceMode.Impulse);
            newSun.GetComponent<Rigidbody>().AddForce(Vector3.right, ForceMode.Impulse);
        }
    }
}
