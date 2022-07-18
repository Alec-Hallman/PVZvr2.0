using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grip_Check_L : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) > 0.5f)
        {
            var funnyhaha = GetComponent<LineRenderer>().enabled = true;
        }
        else if ((OVRInput.Get(OVRInput.Axis1D.PrimaryHandTrigger) < 0.5f))
        {
            var funnyhaha = GetComponent<LineRenderer>().enabled = false;
        }

    }
}
