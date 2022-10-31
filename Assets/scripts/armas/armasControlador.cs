using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class armasControlador : MonoBehaviour
{
    //Dependencias
    controlArmas controlArmas;
    Rigidbody2D rb;
    TextMeshProUGUI textMesh;
    SpriteRenderer sprite;
    Animator Animator;
    movimientoJugador movimientoJugador;
    AudioSource audioSource;

    [SerializeField] public bool armaDeFuego;
    [SerializeField] public bool ballesta = false;

    [Header("Melee")]
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    public bool atacando = false;
           
    [Header("HUD")]
    [SerializeField] private GameObject marcadorBalas;
    [SerializeField] private GameObject marcadorBalasTotales;
    
    [Header("Recarga (FR)")]
    [SerializeField] private Image circuloRecarga;
    private float cooldown_recarga;
    private float tiempo2 = 0;
    [SerializeField] private float tiempoDeRecargaDefault;
    [SerializeField] private float tiempoDeRecarga;
    private bool recargar;
    public bool recargando = false;
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
    public event EventHandler OnShoot;

    [Header("Sonidos")]
    [SerializeField] private AudioClip sonidoAtaque;

    [SerializeField] private AudioClip sonidoRecarga;
    [SerializeField] private AudioClip sonidoRecarga2;

    [SerializeField] private AudioClip sonidoSinBalas;

    private float variable2;
    [SerializeField] private float tiempoBalaRecarga;

    private void Start() 
    {
        controlArmas = GameObject.FindGameObjectWithTag("Player").GetComponent<controlArmas>();

        try{Animator = GetComponent<Animator>();}
        catch (System.Exception){throw;}
        
        sprite = GetComponent<SpriteRenderer>();
        max_capacidad = cantBalas;
        textMesh = GetComponent<TextMeshProUGUI>();

        tiempoDeRecarga = tiempoDeRecargaDefault / controlArmas.rechargeMultiplier;

        movimientoJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<movimientoJugador>();

        audioSource = GetComponent<AudioSource>();
        if (ballesta) {
            cantBalas = controlArmas.flechas;
        }
    }
    private void Update() 
    {
        if (GameManager.EnableInput) {

            if (!armaDeFuego)
            {
                marcadorBalas.SetActive(false); //No tiene munición, se borra el bloque de balas
                marcadorBalasTotales.SetActive(false);
                if(Input.GetButtonDown("Fire1")) Golpe();

                if (!atacando) {
                    mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    mousePosition.z = 0;
                    Vector3 lookAtDirection = mousePosition - transform.position;
                    transform.up = lookAtDirection;
                    sprite.flipX = movimientoJugador.mirandoDerecha ? false : true;
                    //transform.localScale = movimientoJugador.mirandoDerecha ? new Vector3(1, 1, 1) : new Vector3(-1, 1, 1);                    
                }

            }
            else {
                disparar = Input.GetButton("Fire1");

                if (!ballesta) {
                    recargar = Input.GetKeyDown(KeyCode.R);
                    marcadorBalasTotales.SetActive(true);
                }
                else {
                    marcadorBalasTotales.SetActive(false);
                }

                marcadorBalas.SetActive(true);
                ActualizarHudBalas();

                if(recargando) {
                    tiempoDeRecarga = tiempoDeRecargaDefault / controlArmas.rechargeMultiplier;
                    StartCoroutine(TiempoRecargar(tiempoDeRecarga) );
                    circuloRecarga.fillAmount = tiempo2 / tiempoDeRecarga;
                }
                
                if ((recargar && cantBalas != max_capacidad) && !recargando) {
                    StartCoroutine(Recargar(tiempoDeRecarga));                            
                }

                if (disparar && Time.time > dispararPermiso && !recargando) {
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
        

        switch (controlArmas.armaActiva)
        {
            case 1:
                textoBalas.text = controlArmas.sniperAmmo.ToString();
            break;

            case 2:
                textoBalas.text = controlArmas.grenadeAmmo.ToString();
            break;

            case 3: //ballesta
                textMesh.text = controlArmas.flechas.ToString();
            break;

            case 4:
                textoBalas.text = controlArmas.ametralladoraAmmo.ToString();
            break;

            default:
            break;
        }
    }

    private void Disparar()
    {
        dispararPermiso = Time.time + dispararCooldown; 
        if (cantBalas > 0) {
            try {
                Animator.SetTrigger("disparo");
            }
            catch (System.Exception)
            {}
            audioSource.PlayOneShot(sonidoAtaque);
            if (ballesta) {
                controlArmas.flechas--;                
            }
            cantBalas--;
            GameObject bala = Instantiate(Bala, puntaDelArma.position, puntaDelArma.rotation);
            Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
            rb.AddForce(puntaDelArma.right * velocidad , ForceMode2D.Impulse);
            OnShoot?.Invoke(this, EventArgs.Empty);

            ActualizarHudBalas();            
        }
        else {
            audioSource.PlayOneShot(sonidoSinBalas);
        }
    }

    private void Golpe()
    {
        if (atacando) return;

        audioSource.PlayOneShot(sonidoAtaque);
        atacando = true;
        Animator.SetTrigger("ataque");
        try {
            Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);
            foreach (Collider2D colisionador in objetos)
            {
                if (colisionador.CompareTag("Enemigo")) {
                    colisionador.GetComponent<vidaEnemiga>().Golpe();
                }
            }
        }
        catch (System.Exception) { }
    }

    private void terminarAtaque()
    {
        atacando = false;
    }

    public IEnumerator Recargar(float tiempoRecarga)
    {
        balasRecargar = max_capacidad - cantBalas;
        switch (controlArmas.armaActiva)
        {
            case 1:
                if (controlArmas.sniperAmmo > 0) {
                    if (controlArmas.sniperAmmo >= balasRecargar) {
                        cantBalas += balasRecargar;
                        controlArmas.sniperAmmo -= balasRecargar;                        
                    }
                    else {
                        cantBalas += controlArmas.sniperAmmo;
                        controlArmas.sniperAmmo = 0;                        
                    }                    
                }
                else
                    yield break;
            break;
            case 2:
                if (controlArmas.grenadeAmmo > 0) {
                    if (controlArmas.grenadeAmmo >= balasRecargar) {
                        cantBalas += balasRecargar;
                        controlArmas.grenadeAmmo -= balasRecargar;                        
                    }
                    else {
                        cantBalas += controlArmas.grenadeAmmo;
                        controlArmas.grenadeAmmo = 0;                        
                    }                    
                }
                else
                    yield break;
            break;
            case 3:
                if (controlArmas.flechas > 0) {
                    if (controlArmas.flechas >= balasRecargar) {
                        cantBalas += balasRecargar;
                        controlArmas.flechas -= balasRecargar;                        
                    }
                    else {
                        cantBalas += controlArmas.flechas;
                        controlArmas.flechas = 0;                        
                    }                
                }
                else
                    yield break;
            break;
            case 4:
                if (controlArmas.ametralladoraAmmo > 0) {
                    if (controlArmas.ametralladoraAmmo >= balasRecargar) {
                        cantBalas += balasRecargar;
                        controlArmas.ametralladoraAmmo -= balasRecargar;                        
                    }
                    else {
                        cantBalas += controlArmas.ametralladoraAmmo;
                        controlArmas.ametralladoraAmmo = 0;                        
                    }                    
                }
                else
                    yield break;
            break;
            
            default:
            break;
        }
        recargando = true;
        StartCoroutine(RecargarSonido());
        
        cooldown_recarga = Time.time + tiempoRecarga;
        yield return new WaitForSeconds(tiempoRecarga); //cooldown de recarga
        
        audioSource.loop = false;
        recargando = false;
        audioSource.PlayOneShot(sonidoRecarga);
        ActualizarHudBalas();
    }

    public IEnumerator TiempoRecargar(float tiempoRecarga)
    {        
        tiempo2 = cooldown_recarga - Time.time;
        yield return new WaitForSeconds(tiempoRecarga / 100);
    }

    public IEnumerator RecargarSonido()
    {
        while (recargando) {
            audioSource.clip = sonidoRecarga2;
            audioSource.Play();
            yield return new WaitForSeconds(audioSource.clip.length + tiempoBalaRecarga);
        }
    }

    private void OnDrawGizmos()
    {
        if (!armaDeFuego) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
        }
    }
} 