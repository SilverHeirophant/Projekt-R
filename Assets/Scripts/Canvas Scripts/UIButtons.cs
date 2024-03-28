using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    public void EarthScene()
    {
        SceneManager.LoadScene("Earth");
    }

    public void SettingsScene()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player has quit :(");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menue.unity");
    }

    public void Level1Scene()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Level2Scene()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void FinalLevelScene(){
        SceneManager.LoadScene("Level 3");
    }

    public void Credits(){
        SceneManager.LoadScene("CreditScene");
    }


}
