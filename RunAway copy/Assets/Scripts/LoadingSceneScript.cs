using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingSceneScript : MonoBehaviour
{
    public static LoadingSceneScript LSS;
    public static string LevelName = "Menu";

    LoadingSceneScript()
    {

    }

    void Start()
    {
        if (!LSS) LSS = new LoadingSceneScript();
        UnityEngine.SceneManagement.SceneManager.LoadScene(LevelName);

    }

    public static void SetLevelName(string levelName)
    {
        if (!LSS) LSS = new LoadingSceneScript();
        LevelName = levelName;
    }


}
