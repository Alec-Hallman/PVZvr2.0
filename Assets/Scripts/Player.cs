using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int sunCount;
    public TMPro.TextMeshProUGUI sunCounter;
    // Start is called before the first frame update
    void Start()
    {
        sunCount = 0;
        sunCounter.text = string.Format("{0}", sunCount);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddSun(int value)
    {
        sunCount += value;
        sunCounter.text = string.Format("{0}", sunCount);
    }
}
