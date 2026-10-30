using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : MonoBehaviour
{
    private float startTime;
    // Start is called before the first frame update
    void Start()
    {
      startTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        //GetComponent<ParticleSystem>().Play();

        //float currentTime = Time.realtimeSinceStartup - startTime;
        //if (currentTime > 1 && currentTime < 2)
        //{
        //    GetComponent<ParticleSystem>().Play();
        //}
        //else
        //{
        //    GetComponent<ParticleSystem>().Stop();
        //    startTime = Time.realtimeSinceStartup;
        //}
        //if (currentTime < 2)
        //{
        //    GetComponent<ParticleSystem>().Play();

        //}
        //else
        //{
        //    GetComponent<ParticleSystem>().Stop();
        //    startTime = Time.realtimeSinceStartup;
          
        //}
        //Debug.Log(currentTime);
    }
}
