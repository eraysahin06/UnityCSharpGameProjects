using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelAnim : MonoBehaviour
{
    public void Restart()
    {
        SceneManager.LoadScene("Level 1");
    }
}
