using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DirtGlow : MonoBehaviour
{
    public Material glowDirt;
    public Material normalDirt;
    private bool wasHit;
    private bool lastHit;

    private GameObject child { get { return this.transform.GetChild(0).gameObject;  } }
    // Start is called before the first frame update
    void Start()
    {
        wasHit = false;
        lastHit = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (wasHit == true || lastHit == true)
        {
            child.GetComponent<MeshRenderer>().sharedMaterial = glowDirt;
        } else if (wasHit == false && lastHit == false)
        {
            child.GetComponent<MeshRenderer>().sharedMaterial = normalDirt;
        }

        lastHit = wasHit;
        wasHit = false;
    }

    public void RaycastHit()
    {
        wasHit = true;
    }



}

