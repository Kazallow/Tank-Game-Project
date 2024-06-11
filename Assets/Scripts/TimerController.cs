using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerController : MonoBehaviour
{
    public TextMeshProUGUI timerText;  
    public float totalTime = 60f;  
    private float remainingTime;

    
    private const int gameOverSceneIndex = 3;  
    private const int youWinSceneIndex = 4;    

    void Start()
    {
        remainingTime = totalTime;
    }

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
            timerText.text = "Time left : " + Mathf.CeilToInt(remainingTime).ToString();
            
            
            if (GameObject.FindGameObjectsWithTag("Ennemi").Length == 0)
            {
                WinGame();
            }
        }
        else
        {
            CheckGameOver();
        }
    }

    void WinGame()
    {
        
        SceneManager.LoadScene(youWinSceneIndex);
    }

    void CheckGameOver()
    {
        
        if (GameObject.FindGameObjectsWithTag("Ennemi").Length > 0)
        {
            
            SceneManager.LoadScene(gameOverSceneIndex);
        }
        else
        {
            
            WinGame();
        }
    }
}
