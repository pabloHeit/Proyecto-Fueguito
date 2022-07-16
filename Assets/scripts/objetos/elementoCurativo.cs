using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elementoCurativo : MonoBehaviour
{
    [SerializeField] private float curacion; //cambiarlo a int si usamos vida por bloques
    private controladorVidas controladorVidas;
    private bool enRango = false;
    void Start()
    {
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
    }

    void Update()
    {
        if( Input.GetKeyDown(KeyCode.E) && enRango )
        {
            controladorVidas.TomarVida(curacion);
            Destroy(gameObject); //hacerle animacion?
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            enRango = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            enRango = false;
        }
    }
}

