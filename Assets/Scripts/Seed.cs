using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed : MonoBehaviour
{
    public float cooldown;
    public LineController linePointer;
    private bool lastGrab;
    private Vector3 StartPosition;
    private Quaternion StartRotation;
    private float lastPlantedTime;
    private Animation anim;

    // Start is called before the first frame update
    void Start()
    {
        StartPosition = GetComponent<Transform>().position;
        StartRotation = GetComponent<Transform>().rotation;
        lastPlantedTime = -1f;

        AnimationClip clip = new AnimationClip();
        AnimationCurve curve = AnimationCurve.Linear(0, 0.5f, cooldown, 1);
        clip.SetCurve("", typeof(MeshRenderer), "Material._Color.a", curve);
        anim = GetComponentInChildren<Animation>();
        anim.AddClip(clip, "Cooldown");
        clip.wrapMode = WrapMode.Once;
    }

    // Update is called once per frame
    void Update()
    {
        OVRGrabbable GrabCheck = GetComponent<OVRGrabbable>();
        bool isGrabbed = GrabCheck.isGrabbed;
        if (isGrabbed == false && lastGrab == true)
        {
            GetComponent<BoxCollider>().enabled = true;
            GetComponent<Transform>().position = StartPosition;
            GetComponent<Transform>().rotation = StartRotation;
        }
        else if (isGrabbed == true)
        {
            GetComponent<BoxCollider>().enabled = false;
            linePointer.SetSeed(this);
        }
        lastGrab = isGrabbed;

 
    }

    public string GetType()
    {
        string name = GetComponentInChildren<Renderer>().material.name;
        if (name.Contains("Repeater"))
        {
            return "Rep";
        }
        if (name.Contains("Peashooter")){
            return "Pea";
        }
        if (name.Contains("Sunflower")){
            return "Sun";
        }
        if (name.Contains("Wallnutt"))
        {
            return "Nutt";
        }
        if (name.Contains("Chomper"))
        {
            return "Chomp";
        }
        if (name.Contains("Snow"))
        {
            return "Ice";
        }

        return string.Empty;
    }

    public int Cost()
    {
        string name = GetComponentInChildren<Renderer>().material.name;
        if (name.Contains("Peashooter"))
        {
            return 100;
        }
        if (name.Contains("Sunflower"))
        {
            return 50;
        }
        if (name.Contains("Repeater"))
        {
            return 200;
        }
        if (name.Contains("Wallnutt"))
        {
            return 50;
        }
        if (name.Contains("Chomper"))
        {
            return 150;
        }
        if (name.Contains("Snow"))
        {
            return 50;
        }
        throw new System.Exception("No such cost exists");
    }

    public void UpdateSunCount(int total)
    {
        Material m = GetComponentInChildren<Renderer>().sharedMaterial;
        bool cooldownIsFinished = Time.realtimeSinceStartup - lastPlantedTime >= cooldown;
        if (total >= Cost() || cooldownIsFinished) m.color = new Color(1, 1, 1);
        else m.color = new Color(0.5f, 0.5f, 0.5f);
    }

    public void WasPlanted()
    {
        lastPlantedTime = Time.realtimeSinceStartup;
        anim.Play("Cooldown");
    }

    public bool CooldownFinished()
    {
        return Time.realtimeSinceStartup - lastPlantedTime >= cooldown;
    }
}
