using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : MonoBehaviour
{

    public GameObject dirtPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Transform parentTransform = GetComponent<Transform>();

        for (int x = 0; x < 9; x++ )
        {
            for(int y = 0; y < 5; y++)
            {
                GameObject newDirt = GameObject.Instantiate(dirtPrefab);
                newDirt.transform.SetParent(parentTransform);
                newDirt.transform.localPosition = new Vector3(x * 2, 0, y * 2);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
