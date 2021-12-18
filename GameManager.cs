using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverPanel;

    public Text scoreText;
    int score;
    public Text highScore;
    int highscore;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
   
    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("High Score", 0).ToString();
    }

   
    void Update()
    {
        
    }

   public void gameOver()
    {
        ObstacleSpawner.instance.gameOver = true;
        StopScrolling();
        gameOverPanel.SetActive(true);
    }    

    void StopScrolling()
    {
        TextureScroll[] scrollingObjects = FindObjectsOfType<TextureScroll>();

        foreach (TextureScroll t in scrollingObjects)
        {
            t.scroll = false;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }


    public void IncreamentScore()
    {
        score++;
        scoreText.text = score.ToString();

        if(score > PlayerPrefs.GetInt("High Score", 0))
        {
            PlayerPrefs.SetInt("High Score", score);
            highScore.text = score.ToString();
        }
        
    }
}
