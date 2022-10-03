using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class FinPanel : MonoBehaviour
{
    public GameObject gold;
    public int Gold;
    public TextMeshProUGUI goldText;
    
    void Start()
    {
        Gold = PlayerPrefs.GetInt("money");
    }

   
    void Update()
    {
        goldText.text = "GOLDS COLLECTED: " + Gold;
        
    }
}
