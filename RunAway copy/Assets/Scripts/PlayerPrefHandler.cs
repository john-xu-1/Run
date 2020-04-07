using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefHandler : MonoBehaviour
{
    public List<string> Levels;

    public List<bool> GetCompletedLevels()
    {
        List<bool> levelsComplete = new List<bool>();
        foreach(string Level in Levels)
        {
            if (PlayerPrefs.HasKey(Level))
            {
                levelsComplete.Add(GetCompletedLevel(Level, Levels));
            }
            else
            {
                if(Level == Levels[0])
                {
                    levelsComplete.Add(true);
                }
                else
                {
                    levelsComplete.Add(false);
                }
                
            }
        }
        return levelsComplete;
    }

    public static bool GetCompletedLevel(string LevelName, List<string> levels)
    {
        int value = PlayerPrefs.GetInt(LevelName);

        if (value == 1 || LevelName == levels[0]) return true;
        else return false;

    }

    public static void SetLevelComplete(string LevelName, bool isComplete)
    {
        if (isComplete) PlayerPrefs.SetInt(LevelName, 1);
        else PlayerPrefs.SetInt(LevelName, 0);

    }


    public void ResetLevelComplete()
    {
        for(int i = 1; i < Levels.Count; i++)
        {
            string level = Levels[i];
            SetLevelComplete(level, false);
        }
    }
}
