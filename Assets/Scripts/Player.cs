using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private int _sunCount;

    private int sunCount {
        get { return _sunCount; }
        set {
            _sunCount = value;
            sunCounter.text = string.Format("{0}", _sunCount);
            UpdateSeeds();
        }
    }
    public TMPro.TextMeshProUGUI sunCounter;
    // Start is called before the first frame update
    void Start()
    {
        sunCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void UpdateSeeds()
    {
        GameObject[] seedPackets = GameObject.FindGameObjectsWithTag("Seed");
        foreach (GameObject seedObject in seedPackets)
        {
            seedObject.GetComponent<seeds>().UpdateSunCount(sunCount);
        }
    }

    public void AddSun(int value)
    {
        sunCount += value;
    }

    public bool PayWithSun(int cost)
    {
        if (cost > sunCount) return false;
        sunCount -= cost;
        return true;
    }
}
