using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private bool TriggerGrabbed;
    private seeds seed;
    public Transform controllerPosition;
    // Start is called before the first frame update
    void Start()
    {
        
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
        if (Physics.Raycast(cursorRay, out RaycastHit hit))
        {
            //Debug.Log(hit.transform.gameObject.tag);
            if (hit.collider.gameObject.tag == "Dirt")
            {

                hit.collider.gameObject.GetComponent<DirtGlow>().RaycastHit();
                if (OVRInput.Get(OVRInput.Axis1D.SecondaryHandTrigger) < 0.1f && TriggerGrabbed == true)
                {
                    hit.collider.gameObject.GetComponent<DirtGlow>().Plant(seed);
                    Debug.Log("Trigger Let Go " + seed);
                    TriggerGrabbed = false;
                    this.seed = null;
                }
            }

        }
        Debug.DrawRay(transform.position, transform.forward * float.PositiveInfinity);
}
    public void SetSeed(seeds seed)
    {
        this.seed = seed;
    }
}
