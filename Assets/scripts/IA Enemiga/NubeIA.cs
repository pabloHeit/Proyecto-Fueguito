using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NubeIA : MonoBehaviour
{
   Animator anim;
   private Transform player;
   public float VelocidadMov;
   private Vector2 movement;
   private Rigidbody2D rb;
   private bool miraDerecha;
   private controladorVidas controladorVidas;
   private BalaAgua BalaAgua;
   [SerializeField] float cooldown;
   private float VelocidadB = 10f;
   private float ultimoGolpe;   
   public GameObject BalaEnemiga;
   private bool enemigoact = false;
   private NavMeshAgent navMeshAgent;
  [SerializeField] public int vidaEnemiga;
  [SerializeField] private Transform disparador;
  [SerializeField] private GameObject efectoImpacto;
  [SerializeField] private Transform objetivo;
  [SerializeField] private float TiempoBala;

   void Start()
    {
     navMeshAgent = GetComponent<NavMeshAgent>();
     navMeshAgent.updateRotation = false;
     navMeshAgent.updateUpAxis = false;   
     controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
     rb= this.GetComponent<Rigidbody2D>();
     miraDerecha = true;
     anim = GetComponent<Animator>();
     player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
   }

   void Update() 
   {
    if(controladorVidas != null)
    {
        Vector3 lookAtDirection = player.position - disparador.position;
        lookAtDirection.z = 0.0f;
        disparador.right = lookAtDirection;

        if (controladorVidas.vidaJugador != 0)
        {
            enemigoMov();
        }
    }
   }
    private void FixedUpdate() 
    {
        if(controladorVidas != null)
        {
            moveCharacter(movement);
        }      
    }

   private void enemigoMov() 
   {
      Vector3 direction = player.position - transform.position;
      float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
      direction.Normalize();
      movement = direction;

      float distJugador = Vector2.Distance(transform.position, player.position);
      //Debug.Log("Distancia del jugador" + distJugador);

     if (vidaEnemiga < 5)
     {
         enemigoact = true;
     }
     
    if (Mathf.Abs(distJugador)>7 && !enemigoact)
    {
        VelocidadMov = 0.0f;
    } 
    else  
        enemigoact = true;

    if (enemigoact == true)
    {
       anim.SetTrigger("Ataque");
        navMeshAgent.SetDestination(objetivo.position);
        VelocidadMov = 1.5f;

        if (Time.time - ultimoGolpe < cooldown)
        {
            return;
        }
        ultimoGolpe = Time.time; 
        
      }
    }

   void moveCharacter(Vector2 direction)
   {
      rb.MovePosition((Vector2) transform.position + (direction * VelocidadMov * Time.deltaTime));
       if(transform.position.x < player.position.x && !miraDerecha)
        {
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

     private void DisparoAgua()
    {
          GameObject balaene = Instantiate(BalaEnemiga, disparador.position, disparador.rotation);
          Rigidbody2D rb = balaene.GetComponent<Rigidbody2D>();
          rb.AddForce(disparador.right * VelocidadB, ForceMode2D.Impulse);
    }

   public void Golpe()
   {
       vidaEnemiga = vidaEnemiga - 1;
       if(vidaEnemiga == 0)
       Destroy(gameObject);
   }

   private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.tag == "balas")
    {
        Golpe();
    }
   }
 
}

