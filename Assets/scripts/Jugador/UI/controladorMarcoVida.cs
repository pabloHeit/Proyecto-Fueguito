using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorMarcoVida : MonoBehaviour
{
    private Animator Animator;
    private controladorVidas controladorVidas;

    private void Start()
    {
        Animator = GetComponent<Animator>();  
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
        controladorVidas.OnMuerto += marcoMuerte;    
    }
    private void marcoMuerte(object sender, EventArgs e)
    {
        Animator.SetBool("Muerte",true);        
    }
}