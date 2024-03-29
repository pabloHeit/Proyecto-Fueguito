using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movimientoEnemigos : MonoBehaviour 
{
    AudioSource audioSource;
    Animator anim;
    Rigidbody2D rb;
    NavMeshAgent navMeshAgent;
    vidaEnemiga vidaEnemiga;
    Transform player;
    controladorVidas controladorVidas;

    [SerializeField] private Transform objetivo;
    private float distJugador = 100;

    private bool miraDerecha;

    [SerializeField] private float distanciaSegura;
    public float distanciaAtaque;

    public bool enemigoAct = false;
    public bool atacando = false;
    private bool jugadorEnZona;

    private float tiempoPasosContador;
    [SerializeField] private float tiempoPasos = 1f;
    [SerializeField] private AudioClip sonidoPasos;

    private Transform habitacion;

    void Start()
    {
        if (this.transform.parent.parent != null)
            habitacion = this.transform.parent.parent;
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();
        vidaEnemiga = this.GetComponent<vidaEnemiga>();

        objetivo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 

        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();

        miraDerecha = false;

        gameObject.GetComponent<NavMeshAgent>().enabled = false;

        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(controladorVidas != null) {
            distJugador = Vector2.Distance(transform.position, player.position);
            if (enemigoAct) {
                enemigoMov();
                if (!atacando && tiempoPasosContador < Time.time) {
                    tiempoPasosContador = Time.time + tiempoPasos;
                    if(sonidoPasos != null)
                        audioSource.PlayOneShot(sonidoPasos);                    
                }
            }
            else {
                if ((Mathf.Abs(distJugador) < distanciaSegura || vidaEnemiga.vida < vidaEnemiga.vidaInicial)
                    && habitacion.GetComponent<encima>().encierro) {
                    enemigoAct = true;
                }
            }
        }
    }

    private void enemigoMov() 
    {
        if (controladorVidas.vidaJugador <= 0) {
            return;
        }

        if(player.position.x < transform.position.x && miraDerecha) {
            Flip();
        }
        else if(player.position.x > transform.position.x && !miraDerecha) {
            Flip();
        }

        jugadorEnZona = Mathf.Abs(distJugador) <= distanciaAtaque;
        
        atacando = jugadorEnZona;
        anim.SetBool("Atacar", jugadorEnZona);
        gameObject.GetComponent<NavMeshAgent>().enabled = !jugadorEnZona;

        if (!jugadorEnZona) {
            anim.SetBool("caminando", true);
            navMeshAgent.SetDestination(objetivo.position);
        }
    }

    private void Flip()
    {
        miraDerecha = !miraDerecha;
        Vector3 laEscala = transform.localScale;
        laEscala.x *= -1;
        transform.localScale = laEscala;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distanciaSegura);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanciaAtaque);
    }
}