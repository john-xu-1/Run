using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelHandler : MonoBehaviour
{

    public string NextScene;
    public GameObject FailPanel;

    public AudioClip dieaudio;
    //public AudioClip BGaudio;
    //private bool dead = false;


    void Start()
    {

    }

    void Update()
    {
        /*
        if (dead)
        {
            Cursor.lockState = CursorLockMode.None;

            Cursor.visible = true;

        }

        Debug.Log(Cursor.visible);
        */
    }


    public void PlayerDie()
    {
        FailPanel.SetActive(true);

        //dead = true;

        FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().SetCursor(false);

        GetComponent<AudioSource>().clip = dieaudio;
        GetComponent<AudioSource>().Play();


    }


    public void LoadNextScene()
    {

        PlayerPrefHandler.SetLevelComplete(NextScene, true);
        loadtheScene(NextScene);
        FindObjectOfType<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>().SetCursor(false);

    }
    public void ReloadScene()
    {
        loadtheScene(SceneManager.GetActiveScene().name);
        Debug.Log("reload");
    }
    public void LoadMenu()
    {
        loadtheScene("Menu");
        Debug.Log("MNEUENUNUENUEUNEunuh");
    }

    private void loadtheScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
