using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBase : MonoBehaviour
{
    private float counter;
    private float slowedTimer = 10f;
    private bool slowed;
    private float bodyTime = 2f;
    private float timer = 0f;
    private bool dead = false;
    public GameObject headless;
    public GameObject head;
    private Transform gardenTransform;
    private Zombie zombie;
    public float startHealth;
    public int damage { get { return 100; } }
    protected float health;
    protected float speed { get { return 0.45f; } }
    protected int damageSpeed { get { return 1; } }
    protected float startTime;
    protected float startTime2;
    protected GameObject currentlyEating;

    void Timer()
    {
        startTime2 = Time.realtimeSinceStartup;

    }

    void Start()
    {
        health = startHealth;
        gardenTransform = GameObject.FindGameObjectWithTag("Garden").transform;
        currentlyEating = null;
        GetComponent<Transform>().position =
            new Vector3(gardenTransform.position.x + 20, 0.49f, gardenTransform.position.z + (zombie.lane * 2) - 2);
            new Vector3(gardenTransform.position.x + 20, 0.49f, gardenTransform.position.z + (zombie.lane * 2) - 2);
    }

    void Update()
    {
        if (slowed == true)
        {
            counter = Time.realtimeSinceStartup - startTime2;
            gameObject.GetComponent<Rigidbody>().mass = 20;
            GetComponent<Animator>().speed = 0.5f;
            if (counter > slowedTimer)
            {
                Debug.Log("UnFroze");
                gameObject.GetComponent<Rigidbody>().mass = 10;
                GetComponent<Animator>().speed = 1;

                slowed = false;
            }
        }
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(-(speed * Time.smoothDeltaTime * 10), 0, 0), ForceMode.Impulse);

        if(currentlyEating != null && Time.realtimeSinceStartup - startTime > damageSpeed)
        {
            Eat();
            startTime = Time.realtimeSinceStartup;
        }
    }

    public void Initialise(Zombie zombie)
    {
        this.zombie = zombie;
        
    }

    public void HitZombie(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            if (damage != 1200) //if you got hit by a chomper cause they do 1200 damage
            {
                GameObject headlessboi = Instantiate(headless);
                headlessboi.transform.position = transform.position;
            }
            GameObject heads = Instantiate(head);

            heads.transform.position = transform.position;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        //Debug.Log(string.Format("Zombie Collided! {0}", collision.collider.gameObject.tag));
        if (collision.collider.gameObject.tag == "Plant")
        {
            currentlyEating = collision.collider.gameObject;
            startTime = Time.realtimeSinceStartup;
        }
        if (collision.collider.gameObject.tag == "slow")
        {
            Timer();
            slowed = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {

        if (collision.collider.gameObject == currentlyEating)
        {
            currentlyEating = null;
        }
    }

    private void Eat()
    {
        currentlyEating.GetComponent<PlantBase1>().TakeDamage(damage);
    }
    void FixedUpdate()
    {

    }
}
