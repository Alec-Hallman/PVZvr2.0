using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GripCheck : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.5f)
        {
            var funnyhaha = GetComponent<LineRenderer>().enabled = true;
            Ray RightRay = new Ray(transform.position, transform.forward);
            
            RaycastHit hit;
            Physics.Raycast(RightRay,Mathf.Infinity, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Collide);
            
            if (Physics.Raycast(RightRay, out hit))
            {
             
   
            }
        }
        else if ((OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) < 0.5f))
        {
            var funnyhaha = GetComponent<LineRenderer>().enabled = false;
        }

    }
    void OnDrawGizmos()
    {
        Ray RightRay = new Ray(transform.position, transform.forward);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(RightRay);
    }
}


