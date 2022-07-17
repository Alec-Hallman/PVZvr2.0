

[System.Serializable]
public class Level
{
    //these variables are case sensitive and must match the strings "firstName" and "lastName" in the JSON.
    public string type;
    public Zombie[] zombies;
}

[System.Serializable]
public class Zombie
{
    public string type;
    public int lane;
    public int time;
}