using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potato_Lamp : MonoBehaviour
{
    private bool state;
    private float startTime;
    Vector3 startScale = new Vector3(0.1305383f, 0.1305383f, 0.1305383f);
    Vector3 endScale = new Vector3(0.2424618f, 0.2424618f, 0.2424618f);
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.realtimeSinceStartup;
    }

    // Update is called once per frame
    void Update()
    {
        float currentTime = Time.realtimeSinceStartup - startTime;
        if (state == true)
        {
            transform.localScale = Vector3.Slerp(startScale, endScale, currentTime);
        }
        if (state == false)
        {
            transform.localScale = Vector3.Slerp(endScale, startScale, currentTime);
        }

        if (currentTime > 2.0f)
        {

            startTime = Time.realtimeSinceStartup;
            if (state == true)
            {
             state = false;
            }
            else if (state == false)
            {
             state = true;
            }


        }
        
        Debug.Log(currentTime);
    }
}
