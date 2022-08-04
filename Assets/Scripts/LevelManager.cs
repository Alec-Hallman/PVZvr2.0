using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    public int Zomb;
    public int level;
    public GameObject normalZombie;
    private float startTime;
    private Level levelData;
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.realtimeSinceStartup;
        TextAsset levelJson = Resources.Load<TextAsset>(string.Format("Levels/{0}", level));
        levelData = JsonUtility.FromJson<Level>(levelJson.text);
  
    }

    // Update is called once per frame
    void Update()
    {
        Zomb = levelData.zombies.Length;
        int secondsSinceStart = (int) Mathf.Floor(Time.realtimeSinceStartup - startTime);
        // check if we should spawn a zombie
        foreach(Zombie zombie in levelData.zombies)
        {
            if (zombie.time == secondsSinceStart)
            {
                zombie.time = -1; // set the time so we don't spawn it again
                SpawnZombie(zombie);
            }
        }

    }

    private void SpawnZombie(Zombie zombie)
    {
        switch(zombie.type)
        {
            case "normal":
                GameObject newZombie = Instantiate(normalZombie);
                newZombie.GetComponent<ZombieBase>().Initialise(zombie);
                break;
            default:
                break;
        }
    }
}
