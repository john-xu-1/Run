using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiePlayer : MonoBehaviour
{
    public CharacterController characterController;
    public bool isDie;
   
    void Start()
    {
        
    }


    private void OnTriggerEnter(Collider col)
    {
        Debug.Log(col.gameObject.name);
        if (col.transform.tag == "Dieable")
        {
            isDie = true;
            characterController.enabled = false;

            characterController.GetComponent<PlayerScript>().KillPlayer();
        }
    }

    void Update()
    {
        
    }
}
