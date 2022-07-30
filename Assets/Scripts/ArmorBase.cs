using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBase : PlantBase1
{
    GameObject hurt2;
    GameObject hurt1;
    private bool exists = false;
    private bool exists2 = false;
    public GameObject Damage1;
    public GameObject Damage2;
    // Start is called before the first frame update
    void Start()
    {
        health = startHealth;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(health);
        if (dead == true)
        {
            Destroy (hurt2);
            Destroy(this.gameObject);
        }
        if (health < 4800 && health > 2700 && exists == false)
        {
            exists = true;
            hurt1 = Instantiate(Damage1);
            hurt1.transform.position = transform.position;
            hurt1.transform.rotation = transform.rotation;
            foreach (var r in GetComponentsInChildren<Renderer>())
            {
                r.enabled = false;
            }
        }
        if (health < 2700 && exists2 == false)
        {
            Destroy(hurt1);
            exists2 = true;
            hurt2 = Instantiate(Damage2);
            hurt2.transform.position = transform.position;
            hurt2.transform.rotation = transform.rotation;
        }
    }
}
