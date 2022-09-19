using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class movimientoEnemigos : MonoBehaviour 
{
    Animator anim;
    Rigidbody2D rb;
    NavMeshAgent navMeshAgent;

    private Transform player;
    private controladorVidas controladorVidas;
    [SerializeField] private Transform objetivo;
    private float distJugador = 100;

    private bool miraDerecha;

    [SerializeField] private float distanciaSegura;
    [SerializeField] private float distanciaAtaque;

    private bool enemigoAct = false;
    public bool atacando = false;
    private bool jugadorEnZona;
   
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        anim = this.GetComponent<Animator>();

        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;

        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();

        miraDerecha = false;

        gameObject.GetComponent<NavMeshAgent>().enabled = false;
    }

    void Update()
    {
        if(controladorVidas != null) {
            distJugador = Vector2.Distance(transform.position, player.position);
            if (enemigoAct) {
                enemigoMov();
            }
            else {
                if (Mathf.Abs(distJugador) < distanciaSegura) {
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