using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class game : MonoBehaviour
{



    public void Restart()
    {
        SceneManager.LoadScene("Level 1");
    }
}
