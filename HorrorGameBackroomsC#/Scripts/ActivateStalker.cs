using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ActivateStalker : MonoBehaviour
{
    public AudioSource myAudio;
    private void Start()
    {
        StalkerAI.isStalking = false;
        
    }

    void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        StalkerAI.isStalking = true;
        myAudio.Play();
    }


    

}
