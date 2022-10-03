using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicManager : MonoBehaviour
{
    AudioSource audioSource;

    [SerializeField] AudioClip benimKlibim;

    float vol = 1f;
    bool soundOnOff;

    [SerializeField]
    Slider slider;
    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        slider.value = vol;    
        
    }
    private void Start()
    {
        audioSource.clip = benimKlibim;
    }
    // Update is called once per frame
    void Update()
    {
        audioSource.volume = vol;

    }
    public void ChangeVolume(float vol)
    {
        this.vol = vol;
    }
    public void SoundOnOff()
    {
        soundOnOff = !soundOnOff;
        if(soundOnOff)
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Stop();
        }
    }
}
