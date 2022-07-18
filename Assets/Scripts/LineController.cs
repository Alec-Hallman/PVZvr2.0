using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    public GameObject 
    public float range = 100;
    public Transform controllerPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = controllerPosition.position;
        transform.rotation = controllerPosition.rotation;

        Ray cursorRay = new Ray(transform.position, transform.forward*range);
        Physics.Raycast(cursorRay, out hit, 100.0f, 0, QueryTriggerInteraction);
        Debug.DrawRay(transform.position, transform.forward * range);

 

}
}
