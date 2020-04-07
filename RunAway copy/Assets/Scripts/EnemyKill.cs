using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKill : MonoBehaviour
{
    public CharacterController charController;
    public bool isEnemyKill; 

    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Debug.Log("U died ");

            isEnemyKill = true;
            charController.enabled = false;

            charController.GetComponent<PlayerScript>().KillPlayer();

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
