using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterPlantBase1 : PlantBase1
{
    private string name;
    private int ammountZombies = 0;
    private bool exists = false;
    private GameObject Shooter;
    public GameObject shooting;
    private bool WaitFrame2;
    private bool WaitFrame;
    private bool repeat;
    private bool shootAgain;
    private float RepeaterOffset = 0.2f;
    private float startTime;
    public GameObject pea;
    void Start()
    {
        health = startHealth;
        startTime = Time.realtimeSinceStartup;

    }

    void Update()
    {

        if (dead == true)
        {
            Destroy(Shooter);
            Destroy(gameObject);
        }
        name = gameObject.name;
        if (name.Contains("Rep"))
        {
            repeat = true;
        }
 

    }
    void FixedUpdate()
    {
        ammountZombies = 0;
        Ray detectZomb = new Ray(transform.position, transform.forward);
        float currentTime = Time.realtimeSinceStartup - startTime;
        WaitFrame = true;
        Rigidbody rb = GetComponent<Rigidbody>();



        foreach (RaycastHit hit in Physics.RaycastAll(detectZomb))
        {

            if (hit.collider.gameObject.tag == "Zombie")
            {
                ammountZombies = ammountZombies + 1;
                // Make animations for pea shooter and ice shooter
                if (exists == false)
                {
                    exists = true;
                    foreach (var r in GetComponentsInChildren<Renderer>())
                    {
                        r.enabled = false;
                    }
                    Shooter = Instantiate(shooting);
                    Shooter.transform.position = transform.position;
                    Shooter.transform.rotation = transform.rotation;

                }
                if (currentTime > damageSpeed && WaitFrame2 == true)
                {
                    WaitFrame2 = false;
                    startTime = Time.realtimeSinceStartup;
                    Shoot();
                    shootAgain = true;
                    WaitFrame = false;

                }
                if (repeat == true && RepeaterOffset < currentTime && shootAgain == true && WaitFrame == true)
                {
                    Shoot();
                    shootAgain = false;

                }
            }
        }
        if (ammountZombies == 0)
        {
            foreach (var r in GetComponentsInChildren<Renderer>())
            {
                r.enabled = true;
            }
            Destroy(Shooter);
        }
        WaitFrame2 = true;
    }
    public void Shoot()
    {
        GameObject newPea = Instantiate(pea);
        Rigidbody peaBody = newPea.GetComponent<Rigidbody>();
        Vector3 pos = transform.position;
        if (name.Contains("Rep"))
        {
            newPea.transform.position = new Vector3(pos.x + 0.5f, pos.y + 0.1f, pos.z);

        }
        if (name.Contains("Ice") || name.Contains("Pea"))
        {
            newPea.transform.position = new Vector3(pos.x + 0.2f, pos.y + 0.19f, pos.z);

        }
        peaBody.AddForce(new Vector3(0.3f, 0, 0), ForceMode.Impulse);
    }


}
