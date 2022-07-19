using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
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

        Ray cursorRay = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(cursorRay, out RaycastHit hit))
        {
            Debug.Log(hit.transform.gameObject.tag);
            if (hit.collider.gameObject.tag == "Dirt")
            {
                hit.collider.gameObject.GetComponent<DirtGlow>().RaycastHit();
 
            }
            if (hit.collider.gameObject.tag == "Packet")
            {
                Debug.Log("Hit Seeds");
                hit.collider.gameObject.GetComponent<seeds>().RaycastHit();
            }
        }
        Debug.DrawRay(transform.position, transform.forward * float.PositiveInfinity);

 

}
}
