using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int lives;//declare lives
    public int score;//declare score

    public Text livesText;//get lives text
    public Text scoreText;//get score text
    public Text pressSpace;
  
    public bool gameOver;

    [SerializeField] GameObject gameOverPanel;
    private void Start()
    {
        livesText.text = "Lives: " + lives.ToString();//change lives text = Lives: %d
        scoreText.text = "Score: " + score.ToString();//change score text = Score: %d
        Instantiate(pressSpace);
        pressSpace.text = "Press Space To Start!";
        gameOverPanel.GetComponent<RectTransform>().localScale = Vector3.zero;
        gameOverPanel.GetComponent<CanvasGroup>().alpha = 0;
    }
    private void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Text.Destroy(pressSpace);
        }
        
    }
    public void UpdateLives(int livesCount)
    {
        lives += livesCount;//lives count = lives + lives count
        if(lives <= 0)//if lives <= 0
        {
            lives = 0;//equalize lives = 0
            GameOver();//call function: GameOver
        }
        livesText.text = "Lives: " + lives.ToString();//change score lives = Lives: %d

    }

    public void UpdateScore(int scoreCount)
    {
        this.score += scoreCount;
        scoreText.text = "Score: " + score.ToString();//change score text = Score: %d
    }

    public void GameOver()
    {
        gameOver = true;//the game is over
        gameOverPanel.GetComponent<CanvasGroup>().DOFade(1, .5f);
        gameOverPanel.GetComponent <RectTransform>().DOScale(1, .5f);
    }

    public void Retry()
    {
        SceneManager.LoadScene("GameScreen");
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}
