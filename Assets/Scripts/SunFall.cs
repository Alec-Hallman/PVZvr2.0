using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunFall : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private float speed;
    private bool hitGround;
    private float startTime;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(new Vector3(0, -(speed * Time.smoothDeltaTime), 0), ForceMode.Impulse);

        if (hitGround)
        {
            float secondsSinceHit = Time.realtimeSinceStartup - startTime;
            int partialSeconds = (int)Mathf.Floor(secondsSinceHit * 100) % 100;
            Debug.Log(partialSeconds);
            if (partialSeconds < 25)
            {
                fadeOut();
            } else if(partialSeconds < 50)
            {
                fadeIn();
            }
            else if (partialSeconds < 75)
            {
                fadeOut();
            }
            else
            {
                fadeIn();
            }
            Debug.Log(secondsSinceHit);
            if(secondsSinceHit > 5)
            {
                Destroy(gameObject);
            }

        }
    }

    private void fadeIn()
    {
        Animation animation = GetComponent<Animation>();
        animation.Play("FadeIn");
    }

    private void fadeOut()
    {
        Animation animation = GetComponent<Animation>();
        animation.Play("FadeOut");
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("collision!");
        if(collider.gameObject.tag == "Dirt")
        {
            startTime = Time.realtimeSinceStartup;
            hitGround = true;
            speed = 0;
            rb.velocity = Vector3.zero;
        }
    }
}
