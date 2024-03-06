using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2 : MonoBehaviour
{
    [SerializeField] GameObject MainHUD;
    [SerializeField] GameObject MissionComplete;
    
    // Start is called before the first frame update
    void Start()
    {
        MissionComplete.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
