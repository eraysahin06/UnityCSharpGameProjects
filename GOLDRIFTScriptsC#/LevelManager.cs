using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    int levelsUnlocked;
    public Button[] buttons;


    void Start()
    {
        levelsUnlocked = PlayerPrefs.GetInt("levelsUnlocked", 1);

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = false;
        }

        for (int i = 0; i < levelsUnlocked; i++)
        {
            buttons[i].interactable = true;
            if ((buttons[1].interactable) == true)
            {
                buttons[0].interactable = false;
            }
            if ((buttons[2].interactable) == true)
            {
                buttons[1].interactable = false;
            }
            if ((buttons[3].interactable) == true)
            {
                buttons[2].interactable = false;
            }
            if ((buttons[4].interactable) == true)
            {
                buttons[3].interactable = false;
            }
            if ((buttons[5].interactable) == true)
            {
                buttons[4].interactable = false;
            }


        }
    }


}
