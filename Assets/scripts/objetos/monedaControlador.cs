using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monedaControlador : MonoBehaviour
{
    private controladorPuntos controladorPuntos;
    [SerializeField] private float puntosGema;
    private void Start()
    {
        controladorPuntos =  GameObject.FindGameObjectWithTag("Puntaje").GetComponent<controladorPuntos>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {         
            controladorPuntos.SumarPuntos(puntosGema);
            Destroy(gameObject); 
        }            
    }    
}
