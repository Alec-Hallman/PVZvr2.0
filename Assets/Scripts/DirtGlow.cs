using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DirtGlow : MonoBehaviour, IPointerEnterHandler
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

    public void OnPointerEnter(PointerEventData pointer)
    {
        Debug.Log ("Hello");
    }

    public void OnTriggerEnter()
    {
        Debug.Log("Hello");
    }



}

