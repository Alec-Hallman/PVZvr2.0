using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seeds : MonoBehaviour
{
    private bool lastHit;
    public Transform LeftHand;
    public Transform RightHand;
    private bool wasHit;
    private Vector3 startingScale;
    private Transform parent;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private bool wasGrabbed;
    // Start is called before the first frame update
    void Start()
    {
        startingScale = transform.parent.localScale;
        startPosition = transform.localPosition;
        startRotation = transform.localRotation;
        parent = transform.parent;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = LeftHand.rotation;
        transform.position = LeftHand.position;

    }
    void FixedUpdate()
    {
        if (wasHit == true)
        {
            Debug.Log("Running");
            transform.parent.localScale = new Vector3(0.05f, 0.05f, 0.05f);

        }
        else if (wasHit == false && lastHit == false)
        {
            transform.parent.localScale = startingScale;
        }
        lastHit = wasHit;
        wasHit = false;
    }
    public void RaycastHit()
    {
        wasHit = true;
        Debug.Log("I'm hit!");
    }
}
