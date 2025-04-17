using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class StickWalk : MonoBehaviour
{

    public GameObject stick;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            stick.SetActive(true);
        }
    }
}
