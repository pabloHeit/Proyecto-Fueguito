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

    private bool golpeando = false;
   
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    private void Update()
    {
        navMeshAgent.SetDestination(objetivo.position);

        if (controladorVidas.vidaJugador != 0){
            enemigoMov();
        }
    }

    private void atacar()
    {
        controladorVidas.TomarDamage(daño);
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

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "balas")
        {
            Golpe();
        }
    }

    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2) transform.position + (direction * VelocidadMov * Time.deltaTime));
        if(transform.position.x < player.position.x && !miraDerecha){
            rb.velocity = new Vector2(VelocidadMov, 0f);
            Flip();
        }

        else if(transform.position.x > player.position.x && miraDerecha)
        {
            rb.velocity = new Vector2(-VelocidadMov, 0f);
            Flip();
        }

        else if(!miraDerecha)
        {
            rb.velocity = new Vector2(-VelocidadMov, 0f);
        }

        else if(miraDerecha)
        {
            rb.velocity = new Vector2(VelocidadMov, 0f);
        }
   }

    private void Flip()
    {
        miraDerecha = !miraDerecha;
        Vector3 laEscala = transform.localScale;
        laEscala.x *=-1;
        transform.localScale = laEscala;
    }

    private void enemigoMov() 
    {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        movement = direction;

        float distJugador = Vector2.Distance(transform.position, player.position);
        //Debug.Log("Distancia del jugador" + distJugador);

        if (vidaEnemiga < 5){
            enemigoact = true;
        }
        
        if (Mathf.Abs(distJugador) > 7 && !enemigoact){
            VelocidadMov = 0.0f;
        } 
        else{
            enemigoact = true;
        }

        if (Mathf.Abs(distJugador) < 1 && !golpeando){
            VelocidadMov = 0.0f;
            golpeando = !golpeando;
            anim.SetTrigger("Atacar");
        }

        if (enemigoact){
            navMeshAgent.SetDestination(objetivo.position);
            VelocidadMov = 1.5f;

            if (Time.time - ultimoGolpe < cooldown){
                return;
            }
            ultimoGolpe = Time.time; 
            anim.SetTrigger("Enojo");
            //DisparoAgua();
        }
    }
}

