using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class KeyCollect : MonoBehaviour
{
    
    public int KeysCollected = 0;
    public TextMeshProUGUI KeysText;
    public GameObject EscapeDoor;

    private void Start()
    {
        KeysText.text = "x" + KeysCollected.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        
            KeysCollected++;
            KeysText.text = "x" + KeysCollected.ToString();
            Destroy(gameObject);
            if (KeysCollected == 3)
            {
                EscapeDoor.SetActive(true);
            }  
    }
}
