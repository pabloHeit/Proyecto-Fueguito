using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacionDisparo : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] private Transform target;
   // [SerializeField] private Transform puntaDelArma;
    //[SerializeField] private Transform controladorDisparo;
    private Vector3 mousePosition;
    private Transform _t;
    private movimientoJugador movimientoJugador;

    void Start()
	{
        _t = GetComponent<Transform>();
	    sprite = GetComponent<SpriteRenderer>();
        movimientoJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<movimientoJugador>();  	
  	}
    void Update()
    {
        if (GameManager.EnableInput){            
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0;
            Vector3 lookAtDirection = mousePosition - target.position;
            target.right= lookAtDirection;
            sprite.flipY = !movimientoJugador.mirandoDerecha;
        }
    }
}