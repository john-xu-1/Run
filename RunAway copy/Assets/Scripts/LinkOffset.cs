using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkOffset : MonoBehaviour
{
   

    public LinkLoops LinkLoopsR;

    void Start()
    {
        LinkLoopsR.enabled = false;
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.transform.CompareTag("Player"))
        {
            LinkLoopsR.enabled = true;
        }
    }


    void Update()
    {
        
    }
}
