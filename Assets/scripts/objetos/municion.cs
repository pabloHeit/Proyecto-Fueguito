using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class municion : MonoBehaviour
{
    controlArmas controlArmas;
    
    [Tooltip("1: Sniper \n 2: Granadas")]
    [SerializeField] private int tipoMunicion;

    [SerializeField] private int cantidadMunicion;
    void Start()
    {
        controlArmas = GameObject.FindGameObjectWithTag("Player").GetComponent<controlArmas>();

        if (tipoMunicion != 1 && tipoMunicion != 2){
            Debug.LogError($"No se colocó tipoMunicion en una Instancia de munición");            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            if (tipoMunicion == 1){
                controlArmas.sniperAmmo += cantidadMunicion;                
            }
            else if(tipoMunicion == 2){
                controlArmas.grenadeAmmo += cantidadMunicion;                
            }
            Destroy(this.gameObject);
        }
    }
}
