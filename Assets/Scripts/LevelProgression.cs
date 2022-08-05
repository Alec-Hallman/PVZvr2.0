using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgression : MonoBehaviour
{
    private bool Animate;
    private int lastDeads = 0;
    private float interval = 0f;
    private Vector3 startPosition;
    public int deads = 0;
    private int something = 0;
    public int totalZombies;
    public float progressMax = 0.2188581f;
    public float progress = 0f;
    public float progressInterval = 0f;
    public GameObject Controller;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = new Vector3 (0.08959901f, 0.01098074f, 0f);
    }

    // Update is called once per frame
    public void Update()
    {
        if (totalZombies == 0)
        {
            totalZombies = Controller.GetComponent<LevelManager>().Zomb;
            progressInterval = progressMax / totalZombies;
        }
        progress = progressInterval * deads;
        Vector3 endPosition = new Vector3 (0.08959901f, 0.01098074f, progress);
        if(lastDeads != deads)
        {
            Animate = true;
        }
        if (Animate == true)
        {
            transform.localScale = Vector3.Slerp(startPosition, endPosition, interval);
            interval = interval + 0.01f;
            if (interval >= 1)
            {
                interval = 0f;
                Animate = false;
                startPosition = endPosition;
            }
        }


        Debug.Log(deads);

        lastDeads = deads;
    }
}
