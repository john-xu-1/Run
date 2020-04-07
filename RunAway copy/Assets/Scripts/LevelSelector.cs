using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelector : MonoBehaviour
{
    public Button[] buttons;
    public PlayerPrefHandler pph;

    private void Start()
    {
        intializebuttons();
    }

    public void ResetLevelCompletion()
    {
        pph.ResetLevelComplete();

        intializebuttons();
    }

    private void intializebuttons()
    {

        List<bool> activeLevels = pph.GetCompletedLevels();
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = activeLevels[i];
        }
    }

}
