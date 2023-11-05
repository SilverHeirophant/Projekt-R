using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    //public Color TeamColor;
    // Start is called before the first frame update
    private void Start()
    {
        if(MainManager.Instance != null)
        {
            //SetColor(MainManager.Instance.TeamColor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
