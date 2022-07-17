using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(string.Format("Levels/{0}.json", level));
        TextAsset levelJson = Resources.Load<TextAsset>(string.Format("Levels/{0}", level));
        Debug.Log(levelJson);
        Level levelData = JsonUtility.FromJson<Level>(levelJson.text);
        Debug.Log(string.Format("Level type is: {0}", levelData.type));
        foreach (Zombie zombie in levelData.zombies)
        {
            Debug.Log(string.Format("Zombie type is: {0}, time is {1}, lane is {2}", zombie.type, zombie.time, zombie.lane));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
