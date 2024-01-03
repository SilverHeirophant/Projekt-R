using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    [SerializeField] GameObject WinCanvas;
    [SerializeField] GameObject Score;
    [SerializeField] GameObject ScoreNumber;

    
    // Start is called before the first frame update
    void Start()
    {
        WinCanvas.SetActive(false);
    }

    public void YesWin()
    {
        Time.timeScale = 0;
        Score.SetActive(false);
        ScoreNumber.SetActive(false);
        WinCanvas.SetActive(true);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
