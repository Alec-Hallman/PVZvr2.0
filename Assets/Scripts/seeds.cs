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
        string name = GetComponentInChildren<Renderer>().material.name;
        if (name.Contains("Peashooter")){
            return "Pea";
        }
        if (name.Contains("Sunflower")){
            return "Sun";
        }
        return string.Empty;
        
    }

    public int Cost()
    {
        string name = GetComponentInChildren<Renderer>().material.name;
        if (name.Contains("Peashooter"))
        {
            return 100;
        }
        if (name.Contains("Sunflower"))
        {
            return 50;
        }
        throw new System.Exception("No such cost exists");
    }

    public void UpdateSunCount(int total)
    {
        Material m = GetComponentInChildren<Renderer>().sharedMaterial;
        if (total >= Cost()) m.color = new Color(1, 1, 1);
        else m.color = new Color(0.5f, 0.5f, 0.5f);
    }
}
