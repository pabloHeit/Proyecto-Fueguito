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

    [SerializeField] private bool consumida = false;

    private controladorVidas controladorVidas;
    private controlArmas controlArmas;
    private armasControlador armasControlador;
    void Start()
    {
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
        controlArmas = GameObject.FindGameObjectWithTag("Player").GetComponent<controlArmas>();
        armasControlador = GameObject.FindGameObjectWithTag("Player").GetComponent<armasControlador>();
        

        Animator = GetComponent<Animator>();
        if (consumida) /**/ Destroy(Animator);

        //Comprobar que la fuente tenga valores cargados
        if (color != 1 && color != 2 && color != 3){
            Debug.Log("<color=red> controladorFuente object Error : </color>   <b> [No se colocó el color de la fuente en el inspector]  </b>");
        }
        if (damagePoints <=0 && maxLifePoints <=0 && rechargePoints <=0){
            Debug.Log("<color=red> controladorFuente object Error : </color>   <b> [No se colocó valores a alguna fuente]  </b>");
        }
    }
    void Update()
    {
        if(EnRango && Input.GetKeyDown(KeyCode.E) && !consumida && GameManager.EnableInput)
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
            }
            consumida = true;
            Animator.SetBool("Consumida", true);
            Destroy(Animator, 2f);

        }        
    }

    private void SubirDamage(float damagePoints)
    {
        controlArmas.damageMultiplier += damagePoints;
        
    }

    private void SubirMaxLife(float maxLifePoints)
    {
        controladorVidas.vidaMaxima += maxLifePoints;
    }

    private void SubirRecharge(float rechargePoints)
    {
        controlArmas.rechargeMultiplier += rechargePoints;

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
