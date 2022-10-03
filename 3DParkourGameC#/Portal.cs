using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : MonoBehaviour
{
    public int nextSceneIndex;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        pauseMenu.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);

            if(nextSceneIndex > PlayerPrefs.GetInt("levelAt"))
            {
                PlayerPrefs.SetInt("levelAt", nextSceneIndex);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
