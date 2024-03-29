using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class controlArmas : MonoBehaviour
{
    armasControlador armasControlador;    

    public int sniperAmmo;
    public int grenadeAmmo;
    public int flechas;
    public int ametralladoraAmmo;

    // public float damageMultiplier = 1;
    public float rechargeMultiplier = 0;
    private float cambiarPermiso;
    [SerializeField] List<GameObject> activadorArma = new List<GameObject>();

    [SerializeField] List<GameObject> armas = new List<GameObject>();

    // public GameObject[] armas;
    [Tooltip("0: Espada \n 1: Sniper \n 2: Granadas \n 3: Flechas \n 4: Ametralladora")]
    public int armaActiva = 0; //espada 1, rifle 2, lanzagranadas 3 , ballesta 4, ametralladora 5
    private float scrollMouse;
    private int cantDeArmas;
    [SerializeField] private int ultima_activa = 0;

    [Header("HUD")]
    [SerializeField] private Image display_arma;
    [SerializeField] private Sprite[] sprite_arma;

    void Start() {
        foreach (Transform child in transform)
        {         
            if (child.name.Contains("activador"))
            {
                activadorArma.Add(child.gameObject);                
            }
        }

        foreach (GameObject arma in activadorArma)
        {
            armas.Add(arma.transform.GetChild(0).gameObject);
        }
        
        armasControlador = GameObject.FindGameObjectWithTag("ArmaJugador").GetComponent<armasControlador>();
        cantDeArmas = armas.Count;
        CambiarArma();
    }

    void Update() {
        if(!armasControlador.gameObject.activeSelf && armasControlador.gameObject != null) {
            if (GameObject.FindGameObjectWithTag("ArmaJugador").GetComponent<armasControlador>() != null)
            {
                armasControlador = GameObject.FindGameObjectWithTag("ArmaJugador").GetComponent<armasControlador>();                
            }
        }
        
        if(!armasControlador.recargando && GameManager.EnableInput)
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
            if(Input.GetKeyDown(KeyCode.Alpha4)){
                CambiarArma(3);
            }
            if(Input.GetKeyDown(KeyCode.Alpha5)){
                CambiarArma(4);
            }
            
            //Seleccion de arma
            if(Time.time > cambiarPermiso && scrollMouse != 0)
            {
                if (scrollMouse > 0) /**/ armaActiva++;
                else if(scrollMouse < 0) /**/ armaActiva--;
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
        if (armasControlador.atacando)
            return;

        if(n != -1) 
            armaActiva = n;

        if (armaActiva > cantDeArmas - 1) /**/ armaActiva = 0;
        else if(armaActiva <= -1) /**/ armaActiva = cantDeArmas - 1;

        if(activadorArma[armaActiva].activeSelf)
        {
            for (int i = 0; i < cantDeArmas; i++)
            {
                if (i != armaActiva)
                    armas[i].SetActive(false);
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

            if(ultima_activa == armaActiva + 1 || (armaActiva == cantDeArmas - 1 && ultima_activa == 0)) /**/
            {
                ultima_activa = armaActiva;
                armaActiva -= 1;
                CambiarArma();
            }
            else if(ultima_activa == armaActiva - 1) /**/ 
            {
                ultima_activa = armaActiva;
                armaActiva += 1;
                CambiarArma();
            }
        }
    }
}