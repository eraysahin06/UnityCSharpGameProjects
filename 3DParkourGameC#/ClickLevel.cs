using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ClickLevel : MonoBehaviour
{

    public GameObject pauseMenu;

    // Start is called before the first frame update

    public void ChangeScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    private void Start()
    {
        pauseMenu.SetActive(false);
    }
}
