using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoEjemplo : MonoBehaviour
{
    private controladorVidas controladorVidas; 
    private float damage = 10;
    void Start()
    {
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();  	   
    }
    void Update()
    {
        if(Input.GetButtonDown("Fire2"))  //borrar este if, es meramente para ver si funciona
        {
            /* para que el jugador pierda vida se pone 
            controladorVidas.TomarDaño('vida que pierde el jugador')
            tener en cuenta que el máximo de vida es 100
            */
            controladorVidas.TomarDaño(damage); 
        }
    }
}
