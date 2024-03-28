using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public float timer = 105.0f;
    
    public Animator CreditsAnim;
    public Credits2 Assets;
    [SerializeField] GameObject Producers;
    [SerializeField] GameObject Goodbye;
    
    // Start is called before the first frame update
    void Awake()
    {
        Goodbye.SetActive(false);
        
        CreditsAnim = GetComponent<Animator>();
        Assets = GetComponent<Credits2>();
    }

    void Start()
    {
        CreditsAnim.Play("text1");
    }

    void Update(){
        timer -= Time.deltaTime;

        if(timer < 0){
            Producers.SetActive(false);
            Goodbye.SetActive(true);
        }
    }


}
