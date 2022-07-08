using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA2 : MonoBehaviour {
   public Animator anim;
   public Transform player;
   public float VelocidadMov = 5f;
   private Vector2 movement;
   private Rigidbody2D rb;
   private bool miraDerecha;
   float rangoAgro;
   private controladorVidas controladorVidas;
   [SerializeField] private float daño;

   [SerializeField] float cooldown;
   private float ultimoGolpe;
    
   void Start() {
     controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
     rb= this.GetComponent<Rigidbody2D>();
     miraDerecha = true;
     anim = GetComponent<Animator>();
   }

   void Update() {
      Vector3 direction = player.position - transform.position;
      float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
      direction.Normalize();
      movement = direction;

      float distJugador = Vector2.Distance(transform.position, player.position);
      Debug.Log("Distancia del jugador" + distJugador);
      Debug.Log("RANGO AGRO:"+rangoAgro);

      if (distJugador<rangoAgro || Mathf.Abs(distJugador)>1)
        {
            anim.SetBool("Atacar", false);
        }

        else if(Mathf.Abs(distJugador)<1)
        {
         if (Time.time-ultimoGolpe<cooldown){
            return;
         }
           ultimoGolpe= Time.time; 
           anim.SetBool("Atacar", true);
           controladorVidas.TomarDaño(daño);


        }
   }

   private void FixedUpdate() 
   {
      moveCharacter(movement);
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

}