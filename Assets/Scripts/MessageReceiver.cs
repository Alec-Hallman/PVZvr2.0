using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageReceiver : MonoBehaviour
{
    public Material glowDirt;
    public void Glow()
    {
        transform.GetChild(0).GetComponent<MeshRenderer>().sharedMaterial = glowDirt;
    }
}
