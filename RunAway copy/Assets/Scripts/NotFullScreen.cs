using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotFullScreen : MonoBehaviour
{
    
    void Start()
    {
        
    }
    void NoFull()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Screen.fullScreen = false;
            Debug.Log("Foooooooot");
        }
        
    }
    
    void Update()
    {
        NoFull();
    }
}
