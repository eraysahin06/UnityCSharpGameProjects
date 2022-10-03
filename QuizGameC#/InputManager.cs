using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    GameObject Player;

    GameManager GameManager;

    SoundManager SoundManager;

    public string ad;

    private void Awake()
    {
        GameManager= Object.FindObjectOfType<GameManager>();

        Player = GameObject.Find("Player");

        SoundManager = Object.FindObjectOfType<SoundManager>();
    }

    void OnMouseDown()
    {
        if (!GameManager.questGetsAnswered)
        {
            return;
        }
            
        if(this.transform.position.z > Player.transform.position.z && this.transform.position.z < Player.transform.position.z + 2)
        {
            Vector3 mousePos = this.transform.position;
            Player.GetComponent<PlayerMoveManager>().Move(mousePos, 0.5f);
            GameManager.CheckAnswer(ad);
            GameManager.questGetsAnswered=false;
            SoundManager.PlayButtonSound();
        }

    }
}
