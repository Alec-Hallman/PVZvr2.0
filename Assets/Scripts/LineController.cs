using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private bool TriggerGrabbed;
    private Seed seed;
    public Transform controllerPosition;
    private Collider lastCollided;
    private float lastIndexTriggerState;

    // Start is called before the first frame update
    void Start()
    {
        lastCollided = null;  
        lastIndexTriggerState = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
    }
    void Update()
    {
        transform.position = controllerPosition.position;
        transform.rotation = controllerPosition.rotation;
        if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) > 0.5f)
        {
            TriggerGrabbed = true;
        }
    }
    // Update is called once per frame 
    //After plant seed set seed to null
    void FixedUpdate()
    {
        Ray cursorRay = new Ray(transform.position, transform.forward);
        bool seenDirt = false;
        foreach (RaycastHit hit in Physics.RaycastAll(cursorRay))
        {
            if (lastCollided == null) {
                lastCollided = hit.collider;
                return;
            }


                if (hit.collider.gameObject.tag == "Dirt")
                {
                    if (!seenDirt)
                {
                    hit.collider.gameObject.GetComponent<DirtGlow>().RaycastHit();
                    seenDirt = true;

                }
                if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) < 0.1f && TriggerGrabbed == true)
                    {
                        hit.collider.gameObject.GetComponent<DirtGlow>().Plant(seed);
                        Debug.Log("Trigger Let Go " + seed);
                        TriggerGrabbed = false;
                        this.seed = null;
                         return;
                    }
                }

                else if (hit.collider.gameObject.tag == "Sun")
                {
                    // Debug.Log("Hit sun");
                    if (lastCollided != hit.collider)
                    {
                        lastIndexTriggerState = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
                        lastCollided = hit.collider;
                    }

                    if (lastIndexTriggerState < 0.5f && OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger) > 0.5f)
                    {
                        hit.collider.gameObject.GetComponent<SunFall>().Collect();
                        return;
                    }
                    lastIndexTriggerState = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
           
                }
            

            lastCollided = hit.collider;
        }
       // Debug.DrawRay(transform.position, transform.forward * float.PositiveInfinity);

    }

    public void SetSeed(Seed seed)
    {
        this.seed = seed;
    }
}
