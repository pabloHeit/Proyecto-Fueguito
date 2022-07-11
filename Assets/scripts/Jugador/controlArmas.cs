using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class controlArmas : MonoBehaviour
{
    [SerializeField] private float coolDown;
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
    [SerializeField] private GameObject CantBalas;
    [SerializeField] private Transform display_arma_transform;
    void Start(){
        armasControlador = GameObject.FindGameObjectWithTag("ArmaJugador").GetComponent<armasControlador>();
        cantDeArmas = armas.Length;
    }
    void Update(){
//----// Cambio de armas //------------------------------------//
        armasControlador = GameObject.FindGameObjectWithTag("ArmaJugador").GetComponent<armasControlador>();
        if(armasControlador.recargando == false){
            scrollMouse=Input.GetAxisRaw("Mouse ScrollWheel");     
            if(Input.GetKeyDown(KeyCode.Alpha1)){
                armaActiva=0;}
            if(Input.GetKeyDown(KeyCode.Alpha2)){
                armaActiva=1;}
            if(Input.GetKeyDown(KeyCode.Alpha3)){
                armaActiva=2;}
        }
        //Seleccion de arma
        if(Time.time > cambiarPermiso && scrollMouse!=0)
        {
            if (scrollMouse>0){
                armaActiva++;}
            else if(scrollMouse<0){
                armaActiva-=1;}

            if (armaActiva==cantDeArmas){
                armaActiva=0;}
            else if(armaActiva<=-1){
                armaActiva=cantDeArmas-1;}
        }
        //Activar arma
        switch (armaActiva)
        {
            case 0: //manos
                    for (int i = 0; i < cantDeArmas; i++){
                        if (i!=0){
                            armas[i].SetActive(false);}

                        armas[0].SetActive(true);
                        display_arma.sprite = sprite_arma[0];
                        ultima_activa=0;
                    }
            break;

            case 1: //espada
                if(activadorArma[0].activeSelf){ 
                    for (int i = 0; i < cantDeArmas; i++){
                        if (i!=1){
                            armas[i].SetActive(false);}
                    }

                    armas[1].SetActive(true);
                    display_arma.sprite = sprite_arma[1];
                    ultima_activa=1;
                }
                else{
                    if(ultima_activa == 2){
                        armaActiva = 0;}
                    else if(ultima_activa == 0){
                        armaActiva = 2;}
                }
            break;

            case 2: //francotirador
            if(activadorArma[1].activeSelf){ 
                for (int i = 0; i < cantDeArmas; i++){
                    if (i!=2){
                        armas[i].SetActive(false);}
                }

                armas[2].SetActive(true);
                display_arma.sprite = sprite_arma[2];
                ultima_activa=2;
            }
            else{
                if(ultima_activa == 0){
                    armaActiva = 1;}
                else if(ultima_activa == 1){
                    armaActiva = 0;}
            }
            break;

            case 3://lanzagranadas
            if(activadorArma[2].activeSelf){ 
                for (int i = 0; i < cantDeArmas; i++){
                    if (i!=3){
                        armas[i].SetActive(false);}
                }

                armas[3].SetActive(true);
                display_arma.sprite = sprite_arma[3];
                ultima_activa=3;
            }
            else{
                if(ultima_activa == 0){
                    armaActiva = 2;}
                else if(ultima_activa == 2){
                    armaActiva = 0;}
            }
            break;
        }
    }

//----// Activador de armas //------------------------------------//
    public void activarArmas(int x){
        activadorArma[x].SetActive(true);
    }

/* //----// UI Armas //------------//
    private void ArmaMeleeUI{
        
    }
*/
} 
