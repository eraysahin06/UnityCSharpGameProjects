using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameOverScreen gameOverScreen;
    // Start is called before the first frame update
    private void Awake()
    {
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        gameOverScreen.Setup();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameOver();
        Time.timeScale = 0;
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("SelectionScreen");
        Time.timeScale = 1;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

}
