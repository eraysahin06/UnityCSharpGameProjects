using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    
    public GameObject mainMenuScreen;

   public void playGame()
   {
        SceneManager.LoadScene(2);
        Time.timeScale = 1;
        mainMenuScreen.SetActive(false);

    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void resumeGame()
    {
        mainMenuScreen.SetActive(false);
        Time.timeScale = 1;
    }

    public void openMenu()
    {
        mainMenuScreen.SetActive(true);
        Time.timeScale = 0;
    }

    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        Time.timeScale = 1;
    }


    public void goToLevelsScreen ()
    {
        SceneManager.LoadScene(2);
    }

    public void restartGame ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void freePractice ()
    {
        SceneManager.LoadScene (1);
        Time.timeScale = 1;
    }
   
    

}
