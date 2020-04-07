using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalFix : MonoBehaviour
{

    public List<GameObject> platforms;

    void Start()
    {
        foreach(GameObject platform in platforms)
        {
            platform.GetComponent<MeshRenderer>().enabled = false;
        }

        
    }

    
    void Update()
    {
        
    }
}
