using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogonazo : MonoBehaviour
{
    private armasControlador armasControlador;
    private Animator Animator;
    void Start()
    {
        Animator=GetComponent<Animator>();
        armasControlador= GameObject.FindGameObjectWithTag("ArmaJugador").GetComponent<armasControlador>();      
        armasControlador.OnShoot += Fogonazo;
    }
    private void Fogonazo(object sender, EventArgs e)
    {
        Animator.SetTrigger("Disparo");        
    }
}

