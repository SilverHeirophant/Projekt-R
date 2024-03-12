using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public Animator playerAnim;
    public lvl2PC player2Script;
    public enum playerStates {Default, tiltRight, tiltLeft, tiltUp, tiltDown}

    // Start is called before the first frame update
    void Start()
    {
        player2Script = GetComponent<lvl2PC>();
        playerAnim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        //:p
    }
}
