using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColourChange : MonoBehaviour
{
    public bool blue;
    public Material[] skins;
    // Start is called before the first frame update
    void Start()
    {
        blue = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(blue){
            GetComponent<SkinnedMeshRenderer>().material = skins[1];
        } else{
            GetComponent<SkinnedMeshRenderer>().material = skins[0];
        }
    }
}
