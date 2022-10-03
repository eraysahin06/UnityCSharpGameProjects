using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarCollectGold : MonoBehaviour
{
    public GameObject gold;
    public int Gold;
    public TextMeshProUGUI goldText;
  

    void Start()
    {
        Gold = 0;

        Gold = PlayerPrefs.GetInt("money", 0);

        Application.targetFrameRate = 60;
    }


    void Update()
    {
        goldText.text = "GOLD: " + Gold;
        PlayerPrefs.SetInt("money", Gold);

        int currentLevel = SceneManager.GetActiveScene().buildIndex;
        if (PlayerPrefs.GetInt("money") >= 100)
        {
            PlayerPrefs.SetInt("levelsUnlocked", 2);
        }
        if (PlayerPrefs.GetInt("money") >= 250)
        {
            PlayerPrefs.SetInt("levelsUnlocked", 3);
        }
        if (PlayerPrefs.GetInt("money") >= 400)
        {
            PlayerPrefs.SetInt("levelsUnlocked", 4);
        }
        if (PlayerPrefs.GetInt("money") >= 600)
        {
            PlayerPrefs.SetInt("levelsUnlocked", 5);
        }
        if (PlayerPrefs.GetInt("money") >= 800)
        {
            PlayerPrefs.SetInt("levelsUnlocked", 6);
        }
        if (PlayerPrefs.GetInt("money") >= 1000)
        {
            PlayerPrefs.SetInt("levelsUnlocked", 7);
        }
        if (PlayerPrefs.GetInt("money") >= 1200)
        {
            PlayerPrefs.SetInt("levelsUnlocked", 8);
        }
        if (PlayerPrefs.GetInt("money") >= 1400)
        {
            PlayerPrefs.SetInt("levelsUnlocked", 9);
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "gold")
        {
            Gold += 1;
                    
            Destroy(other.transform.gameObject);
        }
    }
}
