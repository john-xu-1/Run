using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public GameObject enemy;

    private void Start()
    {
        enemy.SetActive(false);
    }

    
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            enemy.SetActive(true);
        }
    }
}
