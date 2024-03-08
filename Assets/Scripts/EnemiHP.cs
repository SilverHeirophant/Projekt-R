using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemiHP : MonoBehaviour
{
    //Public variables
    public Slider HBarSlider;
    public Gradient HGradient;
    public Image fill;

    public void SetMaxHealth(int health)
    {
        HBarSlider.maxValue = health;
        HBarSlider.value = health;

        fill.color = HGradient.Evaluate(1f);
    }

    public void SetHealth(int health)
    {
        HBarSlider.value = health;
        fill.color = HGradient.Evaluate(HBarSlider.normalizedValue);
    }

}
