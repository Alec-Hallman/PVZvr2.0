using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBase : PlantBase1
{
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
        if(dead == true)
        {
            Destroy(this.gameObject);
        }
    }
}
