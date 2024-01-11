using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1 : MonoBehaviour
{
    //Level 1 Canvases
    [SerializeField] GameObject MainHUD;
    [SerializeField] GameObject MissionComplete;
    
    // Start is called before the first frame update
    void Start()
    {
        //ones that will be shown at start
        //Dialogue.SetActive(true);

        //ones that will show somewhere after
        MissionComplete.SetActive(false);
        MainHUD.SetActive(false);
    }

    public void MainHUDSpawn()
    {
        //Stops everything
        Time.timeScale = 1;

        MissionComplete.SetActive(false);
        MainHUD.SetActive(true);
    }
}
