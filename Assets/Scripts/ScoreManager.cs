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
    public TextMeshProUGUI maxEnemiesFallen;
    public TextMeshProUGUI currentEnemiesKilled;
    
    private int score = 0;
    private int enemyScore = 5;
    
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

    /*
    public void SubEnemyScore(int scoreToSub)
    {
        enemyScore -= scoreToSub;
        enemyScore.text = "Enemies Left" + enemyScore.ToString();
    }

*/
}
