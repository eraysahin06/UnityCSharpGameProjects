using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverScreen : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void Setup()
    {
        gameObject.SetActive(true);
    }

}
