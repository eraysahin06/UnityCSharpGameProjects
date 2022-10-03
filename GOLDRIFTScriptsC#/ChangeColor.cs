using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{

    public GameObject menu;

    public GameObject colorScreen;

    public void changeColor ()
    {
        menu.SetActive(false);
        colorScreen.SetActive(true);
    }

    public void goBack ()
    {
        colorScreen.SetActive(false);
        menu.SetActive(true);
    }
}
