using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elementoCurativo : MonoBehaviour
{
    [SerializeField] private float curacion; //cambiarlo a int si usamos vida por bloques
    private bool usado = false;
    private controladorVidas controladorVidas;
    void Start()
    {
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && !usado){
            controladorVidas.TomarVida(curacion);
            usado = true;
            Destroy(gameObject); //hacerle animacion?
        }
    }
}
