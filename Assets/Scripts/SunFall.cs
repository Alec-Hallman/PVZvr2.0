using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFall : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private float speed { get {return 0.1f; } }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(0, -(speed * Time.smoothDeltaTime), 0), ForceMode.Impulse);

        if(transform.position.y < -3f)
        {
            Destroy(gameObject);
        }
    }
}
