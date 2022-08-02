using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class N1_IA : MonoBehaviour {
   public Animator anim;
   public Transform player;
   public float VelocidadMov = 5f;
   private Vector2 movement;
   private Rigidbody2D rb;
   private bool miraDerecha;
   private controladorVidas controladorVidas;
   [SerializeField] private float daño;
   [SerializeField] float cooldown;
   private float ultimoGolpe;
   [SerializeField] public int vidaEnemiga;
   private int Health= 5;

    
   void Start()
    {
     controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
     rb= this.GetComponent<Rigidbody2D>();
     miraDerecha = true;
     anim = GetComponent<Animator>();
   }

   void Update() 
   {
    if(controladorVidas != null)
    {
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

   public void Golpe()
   {
       Health= Health - 1;
       if(Health == 0)
       Destroy(gameObject);
   }

}