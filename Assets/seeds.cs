using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seeds : MonoBehaviour
{
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
            GetComponent<Transform>().position = StartPosition;
            GetComponent<Transform>().rotation = StartRotation;

        }
        lastGrab = isGrabbed;
    }
}
