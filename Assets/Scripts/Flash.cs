using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    
    public float totalSeconds;
    public float maxIntensity;
    public Light myLight;
    
    public IEnumerator flashNow()
    {
        float waitTime = totalSeconds / 2;
        
        while (myLight.intensity < maxIntensity)
        {
            myLight.intensity += Time.deltaTime / waitTime;
        }
    
        while (myLight.intensity > 0)
        {
            myLight.intensity -= Time.deltaTime / waitTime;
            yield return null;
        }
    
        yield return null;
    }
}
