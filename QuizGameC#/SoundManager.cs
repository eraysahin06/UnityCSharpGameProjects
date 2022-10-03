using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource button_FX, correct_FX, finish_FX, start_FX, incorrect_FX;

    public void PlayButtonSound()
    {
        button_FX.Play();
    }
    public void PlayCorrectSound()
    {
        correct_FX.Play();
    }
    public void PlayFinishSound()
    {
        finish_FX.Play();
    }
    public void PlayStartSound()
    {
        start_FX.Play();
    }
    public void PlayIncorrectSound()
    {
        incorrect_FX.Play();
    }
}
