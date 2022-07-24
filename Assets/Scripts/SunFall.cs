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
    private GameObject player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = 0.1f;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

        GetComponent<Transform>().LookAt(player.transform);
        //rb.AddForce(new Vector3(0, -(speed * Time.smoothDeltaTime), 0), ForceMode.Impulse);

        if (hitGround)
        {
            float secondsSinceHit = Time.realtimeSinceStartup - startTime;
            int partialSeconds = (int)Mathf.Floor(secondsSinceHit * 100) % 100;
            Blink();
            if (secondsSinceHit >= 5)
            {
                Destroy(gameObject);
            }

        }
    }

    private void Blink()
    {
        Animation animation = GetComponent<Animation>();
        animation.Play("FadeInOut");
    }

    private void OnTriggerEnter(Collider collider)
    { 
        if(collider.gameObject.tag == "Dirt")
        {
            startTime = Time.realtimeSinceStartup;
            hitGround = true;
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().velocity = Vector3.zero;

        }
    }

    public void Collect()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Player>().AddSun(50);
        Destroy(gameObject);
    }
}
