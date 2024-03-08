using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //Level 1 Ring Scoring System
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI numberScore;
    
    //Level 2 downed enemies scoring system
    public TextMeshProUGUI EnemiesLeft;
    public TextMeshProUGUI currentEnemiesKilled;
    [SerializeField] GameObject MainHUD;
    [SerializeField] GameObject MissionComplete;
    
    private int score2 = 0;
    private int score = 0;
    private int maxPoints = 5;
    
    //Initializing the instance of score before the game starts
    private void Awake()
    {
        instance = this;
        
    }
    
    // Start is called before the first frame update
    void Start()
    {
        //scoreText.text = "Score: " + score.ToString();
        
        
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score.ToString();
    }

    public void IncreaseScore(int points)
    {
        score2 += points;
        EnemiesLeft.text = "Enemies Felled: " + score2.ToString();

        if(score2 == maxPoints){
            EndOfTheGame();
        }
    
    }

    void EndOfTheGame(){
        MissionComplete.SetActive(true);

        Time.timeScale = 0f;
    }

}
