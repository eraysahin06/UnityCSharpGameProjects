using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTrigger : MonoBehaviour
{

    public AudioSource Scream;
    public GameObject ThePlayer;
    public GameObject JumpCam;
    public GameObject Flashimg;
    public GameObject RealPlayer;
    public GameObject RestartPanel;

    private void OnTriggerEnter()
    {
        Scream.Play();
        JumpCam.SetActive(true);
        ThePlayer.SetActive(false);
        Flashimg.SetActive(true);
        StartCoroutine(EndJump());
        RealPlayer.SetActive(false);
       
        
    }

    IEnumerator EndJump ()
    {
        yield return new WaitForSeconds(3.5f);
        ThePlayer.SetActive(true);
        //JumpCam.SetActive(false);
        Flashimg.SetActive(false);
        RestartPanel.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        
    }

}
