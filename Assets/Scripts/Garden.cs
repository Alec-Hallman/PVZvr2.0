using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Garden : MonoBehaviour
{
    public GameObject manager;
    private bool waitFrame;
    private int RowCounter;
    public GameObject dirtPrefab;
    public GameObject dirtEndPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        manager.GetComponent<LevelManager>();
       
        int currentLevel = manager.GetComponent<LevelManager>().level;

        if (currentLevel == 1)
        {
            RowCounter = 2;
        }
        if (currentLevel == 2 || currentLevel == 3)
        {
            RowCounter = 3;
        }
        if (currentLevel > 3 && currentLevel < 30)
        {
            RowCounter = 5;
        }
        if (currentLevel > 30)
        {
            RowCounter = 6;
        }
        
        
        Transform parentTransform = GetComponent<Transform>();

        for (int x = 0; x < 9; x++ )
        {
            for(int y = 0; y < RowCounter; y++)
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
