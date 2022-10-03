using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public static void ButonaBasildi1()
    {
        SceneManager.LoadScene("Deneme");
    }
    public static void ButonaBasildi2()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
