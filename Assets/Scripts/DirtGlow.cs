using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DirtGlow : MonoBehaviour, IPointerClickHandler
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

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        Debug.Log("Hello");
        Debug.Log(pointerEventData);
        transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial = glowDirt;
    }

}

