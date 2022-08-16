using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N1_IA : MonoBehaviour {
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

  [SerializeField] public int vidaEnemiga;
  [SerializeField] private Transform disparador;
    
   void Start()
    {
     controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
     rb= this.GetComponent<Rigidbody2D>();
     miraDerecha = true;
     BalaAgua = GetComponent<BalaAgua>();
     anim = GetComponent<Animator>();

     player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
   }

   void Update() 
   {

       
    if(controladorVidas != null)
    {
        Vector3 lookAtDirection = player.position - disparador.position;
        disparador.right= lookAtDirection;

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
      Debug.Log("Distancia del jugador" + distJugador);

     if (vidaEnemiga<5)
     {
         VelocidadMov = 1.5f;
         if (Time.time-ultimoGolpe<cooldown)
         {
            return;
         }
           ultimoGolpe = Time.time; 
           anim.SetBool("Enojo", true);
           DisparoAgua();
        }
     
     if (Mathf.Abs(distJugador)>7)
       {
            anim.SetBool("Enojo", false);
            VelocidadMov = 0.0f;
       } 
        else if((Mathf.Abs(distJugador)<=7))
        {
         VelocidadMov = 1.5f;
         if (Time.time-ultimoGolpe<cooldown)
         {
            return;
         }
           ultimoGolpe = Time.time; 
           anim.SetBool("Enojo", true);
           DisparoAgua();
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
          anim.SetBool("Enojo", false);
          GameObject balaene = Instantiate(BalaEnemiga, disparador.position, disparador.rotation);
          Rigidbody2D rb = balaene.GetComponent<Rigidbody2D>();
          rb.AddForce(disparador.right * VelocidadB, ForceMode2D.Impulse);
                
          /*destroy de game object*/
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