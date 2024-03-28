using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeRemaining = 120.0f;
    public TextMeshProUGUI startText;

    [SerializeField] GameObject Dialogue;
    
    [SerializeField] GameObject MainHUD;
    [SerializeField] GameObject MissionComplete;

    void Update(){
        timeRemaining -= Time.deltaTime;
        startText.text = (timeRemaining).ToString("0");
        
        if(timeRemaining < 0){
            Time.timeScale = 0;

            Dialogue.SetActive(false);
            MainHUD.SetActive(false);
            MissionComplete.SetActive(true);
        }
    }

}
