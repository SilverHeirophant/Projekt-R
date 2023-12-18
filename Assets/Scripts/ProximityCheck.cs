using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityCheck : MonoBehaviour
{
    private Color ogColor;


    void Start()
    {
        ogColor = GetComponent<Renderer>().material.color;
    }

    
    void Update()
    {
        /*
        if (distance < range)
        {
            GetComponent<Renderer>().material.color = Color.cyan;
        }
        
    
        else 
        {
            GetComponent<Renderer>().material.color = ogColor;
        }
    */
    }
    
}
