using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject PauseButton;
    
    void Start()
    {
        PauseMenu.SetActive(false);
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
}
