using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirtGlow : MonoBehaviour
{
    public Material glowDirt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter()
    {
        Debug.Log ("Hello");
        transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial = glowDirt;
    }
    void OnTriggerExit()
    {
        Debug.Log("Hello");
    }

}

