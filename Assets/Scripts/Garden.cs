using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Garden : MonoBehaviour
{

    public GameObject dirtPrefab;
    public GameObject dirtEndPrefab;

    // Start is called before the first frame update
    void Start()
    {
        Transform parentTransform = GetComponent<Transform>();

        for (int x = 0; x < 9; x++ )
        {
            for(int y = 0; y < 5; y++)
            {
                if (x == 0 || x == 8)
                {
                    GameObject newDirt = GameObject.Instantiate(dirtEndPrefab);
                    newDirt.transform.SetParent(parentTransform);
                    newDirt.transform.localPosition = new Vector3(x * 2, 0.03f, y * 2);
                    if (x == 8)
                    {
                        newDirt.transform.Rotate(new Vector3(0, 180f, 0));
                        newDirt.transform.localPosition = new Vector3((x * 2) - 0.01f, 0.03f, y * 2);
                    }
                } 
                else
                {
                    GameObject newDirt = GameObject.Instantiate(dirtPrefab);
                    newDirt.transform.SetParent(parentTransform);
                    newDirt.transform.localPosition = new Vector3(x * 2, 0.03f, y * 2);
                }
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
