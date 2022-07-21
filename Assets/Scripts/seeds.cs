using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seeds : MonoBehaviour
{
    
    public LineController linePointer;
    private bool lastGrab;
    private Vector3 StartPosition;
    private Quaternion StartRotation;
    // Start is called before the first frame update
    void Start()
    {
        StartPosition = GetComponent<Transform>().position;
        StartRotation = GetComponent<Transform>().rotation;
    }

    // Update is called once per frame
    void Update()
    {
        OVRGrabbable GrabCheck = GetComponent<OVRGrabbable>();
        bool isGrabbed = GrabCheck.isGrabbed;
        if (isGrabbed == false && lastGrab == true)
        {
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<Transform>().position = StartPosition;
            GetComponent<Transform>().rotation = StartRotation;


        }
        else if (isGrabbed == true)
        {
            GetComponent<BoxCollider>().enabled = false;
            linePointer.SetSeed(this);
        }
        lastGrab = isGrabbed;
    }
    public string GetType()
    {
        string name = GetComponent<Renderer>().material.name;
        if (name.Contains("Peashooter")){
            return "Pea";
        }
        if (name.Contains("Sunflower")){
            return "Sun";
        }
        return string.Empty;
        
    }
}
