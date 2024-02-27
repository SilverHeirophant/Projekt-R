using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingGround : MonoBehaviour
{
    private float speed = -20;
    private Vector3 startPos;
    private float repeatWidth;
    public GameObject groundPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        repeatWidth = GetComponent<BoxCollider>().size.z / 2;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        
        if(transform.position.z < startPos.z - repeatWidth){
            transform.position = startPos;
        }
    }
}
