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
    private TextMeshProUGUI textMesh;
    
    [Header("Recarga (FR)")]
    [SerializeField] private Image circuloRecarga;
    private float cooldown_recarga;
    private float tiempo2 = 0;
    [SerializeField] private float tiempoDeRecargaDefault;
    [SerializeField] private float tiempoDeRecarga;
    private bool recargar;
    public bool recargando;

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
        if (!armaDeFuego)
        {
            marcadorBalas.SetActive(false); //No tiene munición, se borra el bloque de balas
            if(Input.GetButtonDown("Fire1")) Golpe();
                       
        }
        else
        {    
            marcadorBalas.SetActive(true);

            TextMeshProUGUI textMesh = marcadorBalas.GetComponent<TextMeshProUGUI>();
            textMesh.text = cantBalas.ToString() + "/" + max_capacidad.ToString();

            disparar = Input.GetButton("Fire1");
            recargar = Input.GetKeyDown(KeyCode.R);

            if(recargando)
            {
                tiempoDeRecarga = tiempoDeRecargaDefault / controlArmas.rechargeMultiplier;
                StartCoroutine(TiempoRecargar(tiempoDeRecarga) );        
                circuloRecarga.fillAmount = tiempo2 / tiempoDeRecarga;
            }
            
            if (recargar 
                && cantBalas != max_capacidad
                && !recargando)
            {
                recargando = true;
                StartCoroutine( Recargar(tiempoDeRecarga) );            
            }

            if (disparar 
                && Time.time > dispararPermiso
                && cantBalas > 0
                && !recargando){
                Disparar();
            }
        }        
    }

    private void Disparar()
    {        
        cantBalas--;
        GameObject bala = Instantiate(Bala, puntaDelArma.position, puntaDelArma.rotation);
        dispararPermiso = Time.time + dispararCooldown; 
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        rb.AddForce(puntaDelArma.right * velocidad , ForceMode2D.Impulse);
        OnShoot?.Invoke(this, EventArgs.Empty);        
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

    private void OnDrawGizmos()
    {
        if (!armaDeFuego){
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
        }
    }

    public IEnumerator Recargar(float tiempoRecarga){
        cooldown_recarga = Time.time + tiempoRecarga;
        yield return new WaitForSeconds(tiempoRecarga); //cooldown de recarga
        cantBalas = max_capacidad;
        recargando = false;
    }

    public IEnumerator TiempoRecargar(float tiempoRecarga)
    {        
        tiempo2 = cooldown_recarga - Time.time;
        yield return new WaitForSeconds(tiempoRecarga / 100);
    }
} 