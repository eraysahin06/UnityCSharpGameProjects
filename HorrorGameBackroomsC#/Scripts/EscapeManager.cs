using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EscapeManager : MonoBehaviour
{

    public GameObject YouWinPanel;

    private void Start()
    {
        Time.timeScale = 1;
        YouWinPanel.SetActive(false);
    }

    void OnTriggerEnter()
    {
        Time.timeScale = 0;
        YouWinPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

}

