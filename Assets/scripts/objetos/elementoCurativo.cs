using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elementoCurativo : MonoBehaviour
{
    [SerializeField] private float curacion; 
    private controladorVidas controladorVidas;
    private bool enRango = false;
    void Start()
    {
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            controladorVidas.TomarVida(curacion);
            Destroy(gameObject); //hacerle animacion?
        }
    }   
}