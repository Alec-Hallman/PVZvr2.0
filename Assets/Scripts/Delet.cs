using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delet : MonoBehaviour
{
    protected float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.realtimeSinceStartup;

    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.realtimeSinceStartup - startTime;
        if (currentTime > 1.5f)
        {
            Destroy(gameObject);
        }
    }
}
