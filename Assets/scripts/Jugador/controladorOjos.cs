using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorOjos : MonoBehaviour
{
    private Animator Animator;
    private Vector3 mousePosition;
    [SerializeField] private Transform target;
    [SerializeField] private Transform jugador;
    private Vector3 posicionOjos;

    [SerializeField] private float distanciaMiradaX;
    [SerializeField] private float distanciaMiradaY;

    private movimientoJugador movimientoJugador;
    private controladorVidas controladorVidas;

    private float centroHorizontal = 0;
    private float modificadorCentro = 1f;

    void Start()
    {
        Animator = GetComponent<Animator>();
        movimientoJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<movimientoJugador>();
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
        controladorVidas.OnMuerto += ojosMuerte;    
    }

    void Update()
    {
         mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         mousePosition.z = 0;
         Vector3 lookAtDirection = mousePosition -target.position;     
    Debug.Log($"{lookAtDirection}");
        if (lookAtDirection.x >= distanciaMiradaX)
        {
            posicionOjos.x= jugador.position.x + 0.08f;
            
        }
        else if(lookAtDirection.x <= -distanciaMiradaX)
        {
            posicionOjos.x= jugador.position.x - 0.08f;
        }
        else
        {
            posicionOjos.x= jugador.position.x;
        }

        if (lookAtDirection.y>=distanciaMiradaY)
        {
            posicionOjos.y= jugador.position.y + 0.08f;

        }
        else if(lookAtDirection.y<=-distanciaMiradaY)
        {
            posicionOjos.y= jugador.position.y - 0.08f;
        }
        else
        {
            posicionOjos.y= jugador.position.y;
        }        
        transform.position = posicionOjos;
        //Fin de movimiento de ojos

        if(lookAtDirection.x > centroHorizontal )
        {
            movimientoJugador.mirandoDerecha = true;
            if (centroHorizontal == 0 || centroHorizontal == 1){
                centroHorizontal = -modificadorCentro;                
            }
        }
        else if(lookAtDirection.x < centroHorizontal )
        {
            movimientoJugador.mirandoDerecha = false;
            if (centroHorizontal == 0 || centroHorizontal == -1){
                centroHorizontal = modificadorCentro;                
            }
        }

    }
    private void ojosMuerte(object sender, EventArgs e)
    {
        Animator.SetBool("Muerto",true);        
    }
}
