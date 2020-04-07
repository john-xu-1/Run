using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        LoadingSceneScript.SetLevelName(sceneName);
        SceneManager.LoadScene("Loading");
    }
}
