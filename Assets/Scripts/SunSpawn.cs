using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunSpawn : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sunPrefab;
    private float startTime;
    private float lastSecond;
    private float lastSun;
    private float nextThreshold;
    void Start()
    {
        startTime = Time.realtimeSinceStartup;
        lastSecond = Mathf.FloorToInt(Time.realtimeSinceStartup);
        lastSun = lastSecond;
        nextThreshold = 5 + Random.Range(-2, 2);
    }

    // Update is called once per frame
    void Update()
    {
        int secondsSinceStart = Mathf.FloorToInt(Time.realtimeSinceStartup - startTime);
        // don't check twice in one second
        if (this.lastSecond == secondsSinceStart) return;
        
        // check if we should spawn a sun
        if (secondsSinceStart - lastSun > nextThreshold)
        {
            // spawn sun
            GameObject newSun = Instantiate(sunPrefab);
            Transform sunTransform = newSun.transform;
            int x = Random.Range(-9, 9);
            int z = Random.Range(2, 12);
            sunTransform.position = new Vector3(x, 10, z);

            nextThreshold = 10 + Random.Range(-2, 2);
            lastSun = secondsSinceStart;
        }

        this.lastSecond = secondsSinceStart;
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hello");
    }
}
