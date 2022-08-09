using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class controlArmas : MonoBehaviour
{
    public float damageMultiplier = 1;
    public float rechargeMultiplier = 1;

    private float cambiarPermiso;
    [SerializeField] private GameObject[] activadorArma;

    public GameObject[] armas;
    private int armaActiva = 0; //puños 1, espada 2, rifle 3, lanzagranadas 4 ? 5
    private float scrollMouse;
    private int cantDeArmas;
    private int ultima_activa = 0;
    private armasControlador armasControlador;

    [Header("HUD")]
    [SerializeField] private Image display_arma;
    [SerializeField] private Sprite[] sprite_arma;

    void Start(){
        armasControlador = GameObject.FindGameObjectWithTag("ArmaJugador").GetComponent<armasControlador>();
        cantDeArmas = armas.Length;
        CambiarArma();
    }

    void Update(){        
        armasControlador = GameObject.FindGameObjectWithTag("ArmaJugador").GetComponent<armasControlador>();
        
        if(armasControlador.recargando == false)
        {
            scrollMouse = Input.GetAxisRaw("Mouse ScrollWheel");

            if(Input.GetKeyDown(KeyCode.Alpha1)){
                CambiarArma(0);
            }

            if(Input.GetKeyDown(KeyCode.Alpha2)){
                CambiarArma(1);
            }

            if(Input.GetKeyDown(KeyCode.Alpha3)){
                CambiarArma(2);
            }     
            
            //Seleccion de arma
            if(Time.time > cambiarPermiso && scrollMouse != 0)
            {
                if (scrollMouse > 0) /**/ armaActiva++;
                else if(scrollMouse < 0) /**/ armaActiva -= 1;
                
                if (armaActiva == cantDeArmas) /**/ armaActiva = 0;
                else if(armaActiva <= -1) /**/ armaActiva = cantDeArmas - 1;
                CambiarArma();
            }            
        }
    }

    public void activarArmas(int x){
        activadorArma[x].SetActive(true);
        if( !armasControlador.recargando )
        {
            armaActiva = x;
            CambiarArma();            
        }
    }
    private void CambiarArma(int n = -1)
    {
        if(n != -1) /**/ armaActiva = n;
        
        if(activadorArma[armaActiva].activeSelf)
        {
            for (int i = 0; i < cantDeArmas; i++)
            {
                if (i != armaActiva) /**/ armas[i].SetActive(false);
            }

            armas[armaActiva].SetActive(true);
            display_arma.sprite = sprite_arma[armaActiva];
            ultima_activa = armaActiva;
        }
        else             
        {
            if(n != -1)
            {
                armaActiva = ultima_activa;
                CambiarArma();
                return;
            }
            if(ultima_activa == armaActiva + 1) /**/
            {
                armaActiva -= 1;
                CambiarArma();
            }
            else if(ultima_activa == armaActiva - 1) /**/ 
            {
                armaActiva += 1;
                CambiarArma();
            }
        }
    }
}