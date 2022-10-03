using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public Button playButton;
    public void PlayButtonPressed()
    {
        SceneManager.LoadScene("GameScreen");
    }

}
