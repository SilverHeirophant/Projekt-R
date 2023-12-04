using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBookManager : MonoBehaviour
{
    public static LogBookManager Instance;
    //public Color TeamColor;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
