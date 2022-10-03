using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] Image heart1_Img, heart2_Img, heart3_Img;

    [SerializeField] Sprite heartFilled, heartEmpty, heartHalf;

    PlayerHealthController playerHealthController;

    [SerializeField] TMP_Text gemTxt;

    LevelManager levelManager;

    private void Awake()
    {
        playerHealthController = Object.FindObjectOfType<PlayerHealthController>();
        levelManager = Object.FindObjectOfType<LevelManager>();
    }
    public void UpdateHealth()
    {
        switch(playerHealthController.currentHealth)
        {
            case 6:
                heart1_Img.sprite = heartFilled;
                heart2_Img.sprite = heartFilled;
                heart3_Img.sprite = heartFilled;
                break;
            case 5:
                heart1_Img.sprite = heartFilled;
                heart2_Img.sprite = heartFilled;
                heart3_Img.sprite = heartHalf;
                break;
            case 4:
                heart1_Img.sprite = heartFilled;
                heart2_Img.sprite = heartFilled;
                heart3_Img.sprite = heartEmpty;
                break;
            case 3:
                heart1_Img.sprite = heartFilled;
                heart2_Img.sprite = heartHalf;
                heart3_Img.sprite = heartEmpty;
                break;
            case 2:
                heart1_Img.sprite = heartFilled;
                heart2_Img.sprite = heartEmpty;
                heart3_Img.sprite = heartEmpty;
                break;
            case 1:
                heart1_Img.sprite = heartHalf;
                heart2_Img.sprite = heartEmpty;
                heart3_Img.sprite = heartEmpty;
                break;
            case 0:
                heart1_Img.sprite = heartEmpty;
                heart2_Img.sprite = heartEmpty;
                heart3_Img.sprite = heartEmpty;
                break;
        }    
    }

    public void UpdateGemNumber()
    {
        gemTxt.text = levelManager.collectedGemNo.ToString();
    }
}
