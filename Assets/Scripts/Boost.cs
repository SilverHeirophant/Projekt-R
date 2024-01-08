using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boost : MonoBehaviour
{
    public Slider BBarSlider;
    
    public void SetMaxBoost(int boost)
    {
        BBarSlider.maxValue = boost;
        BBarSlider.value = boost;
    }

    public void SetBoost(int boost)
    {
        BBarSlider.value = boost;
    }
}
