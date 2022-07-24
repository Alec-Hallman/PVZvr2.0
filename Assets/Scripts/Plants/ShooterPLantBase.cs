using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ShooterPlantBase : PlantBase
{
    private bool WaitFrame;
    private bool repeat;
    private bool shootAgain;
    private float RepeaterOffset = 0.2f;
    private float startTime;
    public GameObject pea;
    void Start()
    {

        startTime = Time.realtimeSinceStartup;
    }

    void Update()
    {


        string name = gameObject.name;
        if (name.Contains("Rep"))
        {
            repeat = true;
        }
        Ray detectZomb = new Ray(transform.position, transform.forward);
        float currentTime = Time.realtimeSinceStartup - startTime;
        WaitFrame = true;
        Rigidbody rb = GetComponent<Rigidbody>();
      

            foreach(RaycastHit hit in Physics.RaycastAll(detectZomb))
            {

                        if (hit.collider.gameObject.tag == "Zombie")
            {
                if (currentTime > damageSpeed)
                {
                    startTime = Time.realtimeSinceStartup;
                    Shoot();
                    shootAgain = true;
                    WaitFrame = false;

                }
                if (repeat == true && RepeaterOffset < currentTime && shootAgain == true && WaitFrame == true)
                {
                    Debug.Log("SecondShot");
                    Shoot();
                    shootAgain = false;
                    startTime = Time.realtimeSinceStartup;

                }
            }
            

        }
        Debug.Log(currentTime);
        Debug.Log(RepeaterOffset);

    }
    public void Shoot()
    {
        GameObject newPea = Instantiate(pea);
        Rigidbody peaBody = newPea.GetComponent<Rigidbody>();
        Vector3 pos = transform.position;
        newPea.transform.position = new Vector3(pos.x +0.5f, pos.y + 0.1f, pos.z);
        peaBody.AddForce(new Vector3(0.3f, 0, 0), ForceMode.Impulse);
    }


}
