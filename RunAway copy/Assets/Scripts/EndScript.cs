using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    
    void Start()
    {
        
    }

    
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.CompareTag("End"))
        {
            FindObjectOfType<LevelHandler>().LoadNextScene();

            PlayerPrefHandler.SetLevelComplete(SceneManager.GetActiveScene().name, true);
        }
    }


    void Update()
    {
        
    }
}
