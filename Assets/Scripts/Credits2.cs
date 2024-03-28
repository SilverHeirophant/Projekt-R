using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits2 : MonoBehaviour
{
    public Animator CreditsAnim;
    
    // Start is called before the first frame update
    void Awake()
    {
        CreditsAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Start()
    {
        CreditsAnim.Play("Assets");
    }
}
