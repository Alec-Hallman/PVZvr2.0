using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DirtGlow : MonoBehaviour
{
    private GameObject PlantObject;
    public Material glowDirt;
    public Material normalDirt;
    private bool wasHit;
    private bool lastHit;

    private GameObject child { get { return this.transform.GetChild(0).gameObject;  } }
    // Start is called before the first frame update
    void Start()
    {
        wasHit = false;
        lastHit = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (wasHit == true || lastHit == true)
        {
            child.GetComponent<MeshRenderer>().sharedMaterial = glowDirt;
        } else if (wasHit == false && lastHit == false)
        {
            child.GetComponent<MeshRenderer>().sharedMaterial = normalDirt;
        }

        lastHit = wasHit;
        wasHit = false;
    }

    public void RaycastHit()
    {
        wasHit = true;
    }
    public void Plant(seeds seed)
    {
        if (seed == null)
        {
            return;
        }
        string type = seed.GetType();
        Debug.Log(type);
        PlantObject = Instantiate(Resources.Load<GameObject>("Prefabs/" + type));
        Debug.Log(string.Format("x: {0} y: {1} z: {2}", PlantObject.transform.position.x, PlantObject.transform.position.y, PlantObject.transform.position.z));
        PlantObject.transform.parent = gameObject.transform;
        PlantObject.transform.localPosition = PlantObject.transform.position;
        PlantObject.transform.Rotate(0, 90, 0);
    }



}

