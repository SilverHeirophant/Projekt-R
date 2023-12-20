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

}
