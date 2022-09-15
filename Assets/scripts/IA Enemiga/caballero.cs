using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class caballero : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool miraDerecha;
    [SerializeField] private Transform objetivo;
    private NavMeshAgent navMeshAgent;
    [SerializeField] public int vidaEnemiga;
    [SerializeField] private GameObject enemigo;
    private controladorVidas controladorVidas;
     private bool enemigoact = false;
    private Transform player;
     private Vector2 movement;
    [SerializeField] float cooldown;
    private float ultimoGolpe;
    public float VelocidadMov;
    Animator anim;
    [SerializeField] private float daño;
    [SerializeField] private float distanciaAtaque;
    [SerializeField] private float radioAtaque;
    // [SerializeField] private Transform espada;

    private bool golpeando = false;
   
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        anim = this.GetComponent<Animator>();
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = this.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // navMeshAgent.SetDestination(objetivo.position);

        if (controladorVidas.vidaJugador != 0){
            enemigoMov();
            anim.SetBool("caminando",true);
        }
        Debug.Log("Golpeando: " + golpeando);
    } 

    private void atacar()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, radioAtaque);
        foreach (Collider2D colisionador in objetos){
            if (colisionador.CompareTag("Player")){
                controladorVidas.TomarDamage(daño);
            }
        }
        golpeando = false;
    }

    public void Golpe()
    {
        vidaEnemiga = vidaEnemiga - 1;
        if(vidaEnemiga == 0){
            SpawnEnemigo();
            Destroy(gameObject);
        }
    }

    private void SpawnEnemigo()
    {
        Instantiate(enemigo, transform.position, transform.rotation);
        Instantiate(enemigo, transform.position, transform.rotation);
    }


    private void Flip()
    {
        miraDerecha = !miraDerecha;
        Vector3 laEscala = transform.localScale;
        laEscala.x *= -1;
        transform.localScale = laEscala;
    }

    private void enemigoMov() 
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;

        float distJugador = Vector2.Distance(transform.position, player.position);

        if(player.position.x < transform.position.x && miraDerecha){
            Flip();
        }
        else if(player.position.x > transform.position.x && !miraDerecha){
            Flip();
        }
        
        if (Mathf.Abs(distJugador) > 7 && !enemigoact){
            navMeshAgent.speed = 0;
        } 
        else{
            enemigoact = true;
        }

        if (Mathf.Abs(distJugador) < distanciaAtaque && !golpeando){
            golpeando = true;
            anim.SetTrigger("Atacar");
            navMeshAgent.speed = 0;
            navMeshAgent.acceleration = 0;
        }

        if (enemigoact && !golpeando){
            navMeshAgent.speed = VelocidadMov;
            navMeshAgent.acceleration = 8;
            navMeshAgent.SetDestination(objetivo.position);

            if (Time.time - ultimoGolpe < cooldown){
                return;
            }
            ultimoGolpe = Time.time; 
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "balas")
        {
            Golpe();
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanciaAtaque);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioAtaque);
    }
}