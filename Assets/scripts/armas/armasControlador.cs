using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class armasControlador : MonoBehaviour
{
    [SerializeField] public bool armaDeFuego;

    [Header("Melee")]
    private Animator Animator;
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    SpriteRenderer sprite;
           
    [Header("HUD")]
    [SerializeField] private GameObject marcadorBalas;
    [SerializeField] private GameObject marcadorBalasTotales;
    private TextMeshProUGUI textMesh;
    
    [Header("Recarga (FR)")]
    [SerializeField] private Image circuloRecarga;
    private float cooldown_recarga;
    private float tiempo2 = 0;
    [SerializeField] private float tiempoDeRecargaDefault;
    [SerializeField] private float tiempoDeRecarga;
    private bool recargar;
    public bool recargando;
    private int balasRecargar;

    [Header("Balas (FR)")]
    [SerializeField] public int cantBalas;
    public int max_capacidad;

    [Header("Disparo (FR)")]
    [SerializeField] private Transform puntaDelArma;
    [SerializeField] private GameObject Bala;
    [SerializeField] private float dispararCooldown;
    [SerializeField] private float velocidad;
    private Vector3 mousePosition;
    private float dispararPermiso;
    private bool disparar;
    private Rigidbody2D rb;
    public event EventHandler OnShoot;

    //Dependencias
    private controlArmas controlArmas;


    private void Start() 
    {
        recargando = false;  
        controlArmas = GameObject.FindGameObjectWithTag("Player").GetComponent<controlArmas>();

        try{Animator = GetComponent<Animator>();}
        catch (System.Exception){throw;}
        
        sprite = GetComponent<SpriteRenderer>();
        max_capacidad = cantBalas;
        textMesh = GetComponent<TextMeshProUGUI>();

        tiempoDeRecarga = tiempoDeRecargaDefault / controlArmas.rechargeMultiplier;
    }
    private void Update() 
    {
        if (GameManager.EnableInput){

            if (!armaDeFuego)
            {
                marcadorBalas.SetActive(false); //No tiene munición, se borra el bloque de balas
                marcadorBalasTotales.SetActive(false);
                if(Input.GetButtonDown("Fire1")) Golpe();                       
            }
            else{
                marcadorBalas.SetActive(true); //optimizar esto
                marcadorBalasTotales.SetActive(true);
                ActualizarHudBalas();

                disparar = Input.GetButton("Fire1");
                recargar = Input.GetKeyDown(KeyCode.R);

                if(recargando){
                    tiempoDeRecarga = tiempoDeRecargaDefault / controlArmas.rechargeMultiplier;
                    StartCoroutine(TiempoRecargar(tiempoDeRecarga) );        
                    circuloRecarga.fillAmount = tiempo2 / tiempoDeRecarga;
                }
                
                if (recargar 
                    && cantBalas != max_capacidad
                    && !recargando)
                {
                    if (controlArmas.armaActiva == 1 && controlArmas.sniperAmmo > 0)
                    {
                        recargando = true;
                        StartCoroutine( Recargar(tiempoDeRecarga) );                    
                    }
                    else if(controlArmas.armaActiva == 2 && controlArmas.grenadeAmmo > 0)
                    {
                        recargando = true;
                        StartCoroutine( Recargar(tiempoDeRecarga) );
                    }
                }

                if (disparar 
                    && Time.time > dispararPermiso
                    && cantBalas > 0
                    && !recargando){
                    Disparar();
                }
            }        
        }
    }

    public void ActualizarHudBalas()
    {
        TextMeshProUGUI textMesh = marcadorBalas.GetComponent<TextMeshProUGUI>();
        textMesh.text = cantBalas.ToString() + "/" + max_capacidad.ToString();
        TextMeshProUGUI textoBalas = marcadorBalasTotales.GetComponent<TextMeshProUGUI>();
        
        if (controlArmas.armaActiva == 1)
            textoBalas.text = controlArmas.sniperAmmo.ToString();
        else
            textoBalas.text = controlArmas.grenadeAmmo.ToString();


    }

    private void Disparar()
    {        
        cantBalas--;
        GameObject bala = Instantiate(Bala, puntaDelArma.position, puntaDelArma.rotation);
        dispararPermiso = Time.time + dispararCooldown; 
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        rb.AddForce(puntaDelArma.right * velocidad , ForceMode2D.Impulse);
        OnShoot?.Invoke(this, EventArgs.Empty);

        ActualizarHudBalas();     
    }

    private void Golpe()
    {
        try{
            Animator.SetTrigger("ataque");
            Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);
            foreach (Collider2D colisionador in objetos)
            {
                if (colisionador.CompareTag("Enemigo"))
                {
                    Debug.Log("Le pegaste al enemigo");
                    //colisionador.transform.GetComponent<Enemigo>().TomarDaño(dañoGolpe);
                }
            }            
        }
        catch (System.Exception){Debug.Log("Golpeaste");} 
    }


    public IEnumerator Recargar(float tiempoRecarga){

        cooldown_recarga = Time.time + tiempoRecarga;
        yield return new WaitForSeconds(tiempoRecarga); //cooldown de recarga
        balasRecargar = max_capacidad - cantBalas;

        if (controlArmas.armaActiva == 1){
            if (controlArmas.sniperAmmo >= balasRecargar){
                cantBalas += balasRecargar;
                controlArmas.sniperAmmo -= balasRecargar;
            }
            else
            {
                cantBalas += controlArmas.sniperAmmo;
                controlArmas.sniperAmmo = 0;
            }
        }
        else if(controlArmas.armaActiva == 2){
            if (controlArmas.grenadeAmmo >= balasRecargar){
                cantBalas += balasRecargar;
                controlArmas.grenadeAmmo -= balasRecargar;
            }
            else
            {
                cantBalas += controlArmas.grenadeAmmo;
                controlArmas.grenadeAmmo = 0;
            }
        }

        recargando = false;
        ActualizarHudBalas();
    }

    public IEnumerator TiempoRecargar(float tiempoRecarga)
    {        
        tiempo2 = cooldown_recarga - Time.time;
        yield return new WaitForSeconds(tiempoRecarga / 100);
    }
    private void OnDrawGizmos()
    {
        if (!armaDeFuego){
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
        }
    }
} 