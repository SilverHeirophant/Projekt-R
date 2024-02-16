using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    
    //Pre Level 1 || Earth Scene Canvas
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject PauseButton;
    [SerializeField] GameObject MissionMenu;
    [SerializeField] GameObject Mission1UI;
    [SerializeField] GameObject Mission2UI;
    
    void Start()
    {
        //true ones || Earth
        PauseMenu.SetActive(false);
        Mission1UI.SetActive(false);
        Mission2UI.SetActive(false);
        //false ones
        MissionMenu.SetActive(true);
        
        
    }

    public void Pause()
    {
        Time.timeScale = 0;
        PauseButton.SetActive(false);
        PauseMenu.SetActive(true);
        Debug.Log("paus");
    }
    public void Resume()
    {
        Time.timeScale = 1;
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        Debug.Log("no more paus");
    }

    public void MissionMenuSpawn()
    {
        Mission1UI.SetActive(false);
        MissionMenu.SetActive(true);
    }

    public void Mission1UISpawn()
    {
        MissionMenu.SetActive(false);
        Mission1UI.SetActive(true);
    }

    public void Mission2UISpawn(){
        MissionMenu.SetActive(false);
        Mission2UI.SetActive(true);
    }

}
