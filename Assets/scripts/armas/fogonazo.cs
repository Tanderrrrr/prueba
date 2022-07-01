using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogonazo : MonoBehaviour
{
    private disparosJugador disparosJugador;
    private Animator Animator;
    void Start()
    {
        Animator=GetComponent<Animator>();
        disparosJugador= GameObject.FindGameObjectWithTag("ArmaJugador").GetComponent<disparosJugador>();      
      
    }

    private void Fogonazo(object sender, EventArgs e)
    {
        Animator.SetTrigger("Disparo");        
    }
}