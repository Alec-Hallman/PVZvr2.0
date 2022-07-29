using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Headless : MonoBehaviour
{
    private float timer;
    private float goal = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timer > goal)
        {
            Destroy(gameObject);
        }
        timer = timer + 0.005f;
    }
}
