using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgression : MonoBehaviour
{
    private int dead = 0;
    private int something = 0;
    public int totalZombies;
    public float progressMax = 0.2188581f;
    public float progress = 0f;
    public float progressInterval = 0f;
    public GameObject Controller;
    // Start is called before the first frame update
    void Start()
    {
        dead = 0;
    }

    // Update is called once per frame
    public void Update()
    {
        if (totalZombies == 0)
        {
            totalZombies = Controller.GetComponent<LevelManager>().Zomb;
            progressInterval = progressMax / totalZombies;
        }

        transform.localScale = new Vector3(0.08959901f, 0.01098074f, progress);


        Debug.Log(dead);
    }
}
