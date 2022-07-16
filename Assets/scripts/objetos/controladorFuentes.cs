using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorFuentes : MonoBehaviour
{
    [Tooltip("Rojo: 1\nVerde 2\nAzul 3")]
    [SerializeField] private int color = 0;
    private bool EnRango;
    private Animator Animator;
    [Header("Rojo")]
    [SerializeField] private float damagePoints;
    [Header("Verde")]
    [SerializeField] private float maxLifePoints;
    [Header("Azul")]
    [SerializeField] private float rechargePoints;

    [SerializeField] private bool usada = false;

    private controladorVidas controladorVidas;
    void Start()
    {
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
        Animator = GetComponent<Animator>();
        if (usada)
        {
            //Animator.SetBool("usado???????")            ;
        }
    }
    void Update()
    {
        if(EnRango && Input.GetKeyDown(KeyCode.E) && !usada)
        {
            //Animator.SetBool("nombreDeAnimacion"); Animación de agua consumida?
            switch(color){
                case 1: //rojo
                    SubirDamage(damagePoints);
                break;

                case 2: //verde
                    SubirMaxLife(maxLifePoints);
                break;
                
                case 3: //azul
                    SubirRecharge(rechargePoints);
                break;

                default:

                break;
            }
            usada = true;            
        }        
    }

    private void SubirDamage(float damagePoints)
    {
        
    }

    private void SubirMaxLife(float maxLifePoints)
    {
        controladorVidas.vidaMaxima += maxLifePoints;
    }

    private void SubirRecharge(float rechargePoints)
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            EnRango = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player")){
            EnRango = false;
        }
    }
}
