using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class municion : MonoBehaviour
{
    controlArmas controlArmas;
    
    [Tooltip("1: Sniper \n 2: Granadas \n 3: Flechas \n 4: Ametralladora")]
    [SerializeField] private int tipoMunicion;

    [SerializeField] private int cantidadMunicion;
    void Start()
    {
        controlArmas = GameObject.FindGameObjectWithTag("Player").GetComponent<controlArmas>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player"){
            switch (tipoMunicion)
            {
                case 1:
                    controlArmas.sniperAmmo += cantidadMunicion;
                break;
                case 2:
                   controlArmas.grenadeAmmo += cantidadMunicion;
                break;
                case 3:
                   controlArmas.flechas += cantidadMunicion;
                break;
                case 4:
                    controlArmas.ametralladoraAmmo += cantidadMunicion;
                break;
                default:
                    Debug.LogError($"No se especifico el tipo de munición en {this}");
                break;
            }
            controlArmas.armasControlador.ActualizarHudBalas();

            Destroy(this.gameObject);
        }
    }
}
