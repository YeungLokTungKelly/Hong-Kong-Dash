using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDestroyer : MonoBehaviour
{
    public GameObject platformDestructionPoint;

   
    void Start()
    {
        platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
        
    }

    //From the detruction point stated in Unity, destroy the obejcts out of the area
    void Update()
    {
        if (transform.position.x < platformDestructionPoint.transform.position.x)
        {
            gameObject.SetActive(false);
        }
        
    }
}
