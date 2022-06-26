using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorOjos : MonoBehaviour
{
    [SerializeField] private Transform apuntado;
    private Animator Animator;
    private Vector3 mousePosition;
    [SerializeField] private Transform target;
    [SerializeField] private Transform jugador;
    [SerializeField] private Vector3 ojosLugar;
    private Vector3 posicionOjos;
    [SerializeField] private float distanciaMiradaX;
    [SerializeField] private float distanciaMiradaY;
    private movimientoJugador movimientoJugador;
    private Transform _t;
    private controladorVidas controladorVidas;

    void Start()
    {
        Animator = GetComponent<Animator>();
        _t = GetComponent<Transform>();
        movimientoJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<movimientoJugador>();

        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
        controladorVidas.OnMuerto += ojosMuerte;    
    }

    void Update()
    {
         mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         mousePosition.z = 0;
         Vector3 lookAtDirection = mousePosition -target.position;     

        //Movimiento de los ojos (habra una mejor manera de hacerlo?)
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

        if(lookAtDirection.x > 0 )
        {
            movimientoJugador.mirandoDerecha = true;
        }
        else if(lookAtDirection.x < 0 )
        {
            movimientoJugador.mirandoDerecha = false;
        }

    }
    private void ojosMuerte(object sender, EventArgs e)
    {
        Debug.Log("HOLA");
        Animator.SetBool("Muerto",true);        
    }
}
