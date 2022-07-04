using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class objetoComprable : MonoBehaviour
{
    private controladorPuntos controladorPuntos;
    [SerializeField] private int precio;
    private bool EnRango;
    private agarrarArma agarrarArma;
    [SerializeField] private GameObject precioMarcador;
    void Start()
    {
        agarrarArma = GetComponent<agarrarArma>();
        controladorPuntos = GameObject.FindGameObjectWithTag("Puntaje").GetComponent<controladorPuntos>();
        precioMarcador.GetComponent<TextMeshPro>().text = "$ " + precio.ToString();
    }

    void Update()
    {
        if(EnRango && Input.GetKeyDown(KeyCode.E)){
            comprar();
        }        
    }

    private void comprar()
    {
        if(controladorPuntos.puntos >= precio)
        {
            controladorPuntos.RestarPuntos(precio);
            Destroy(gameObject);
            agarrarArma.agarrar();
        }
        else
        {
            Debug.Log("Dinero insuficiente");
        }
    }    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            EnRango = true;
        }        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            EnRango = false;
        }
    }
}
