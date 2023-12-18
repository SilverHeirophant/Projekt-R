using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScreen : MonoBehaviour
{
    
    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject PauseButton;
    
    private bool isGamePaused;


    // Start is called before the first frame update
    void Start()
    {
        PauseMenu.SetActive(false);
    }

    
    public void Pause()
    {
        Time.timeScale = 0f;
        PauseButton.SetActive(false);
        PauseMenu.SetActive(true);
        isGamePaused = true;
    }
    
    public void Resume()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        isGamePaused = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused == false)
            {
                Pause();
                Debug.Log("paus");
            }
        
            /*
            else if(isGamePaused == true)
            {
                Resume();
                Debug.Log("no paus");
            }
            */
        }
    }
}
