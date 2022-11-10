using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorOjos : MonoBehaviour
{
    movimientoJugador movimientoJugador;
    Animator Animator;

    [SerializeField] private Transform target;
    [SerializeField] private Transform jugador;

    private Vector3 posicionOjos;
    private Vector3 mousePosition;

    [SerializeField] private float distanciaMiradaX;
    [SerializeField] private float distanciaMiradaY;

    [SerializeField] private float movimientoOjos = 0.08f;

    private float centroHorizontal = 0;
    private float modificadorCentro = 1f;


    void Start()
    {
        Animator = GetComponent<Animator>();
        movimientoJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<movimientoJugador>();
    }

    void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 lookAtDirection = mousePosition - target.position;
        //Cambiar distancia mirada X e Y
        if (lookAtDirection.x >= distanciaMiradaX){
            posicionOjos.x= jugador.position.x + movimientoOjos;
            distanciaMiradaX = 0.4f;          
        }
        else if(lookAtDirection.x <= -distanciaMiradaX){
            posicionOjos.x= jugador.position.x - movimientoOjos;
            distanciaMiradaX = 0.4f;
        }
        else{
            posicionOjos.x = jugador.position.x;
            distanciaMiradaX = 0.5f;
        }

        if (lookAtDirection.y >= distanciaMiradaY){
            posicionOjos.y = jugador.position.y + movimientoOjos;
            distanciaMiradaY = 0.4f;
        }
        else if(lookAtDirection.y <= -distanciaMiradaY){
            posicionOjos.y = jugador.position.y - movimientoOjos;
            distanciaMiradaY = 0.4f;
        }
        else{
            posicionOjos.y = jugador.position.y;
            distanciaMiradaY = 0.5f;
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
}
