using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IaEnemiga : MonoBehaviour
{
    public Animator anim;
    [SerializeField]
    Transform player;
    
    [SerializeField]
    float rangoAgro;
    public float VelocidadMov;
    private bool miraDerecha;
    private float DistEntre;
    Rigidbody2D rb2d;

    void Start()
    {
        miraDerecha = true;
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distJugador = Vector2.Distance(transform.position, player.position);
        Debug.Log("Distancia del jugador" + distJugador);
        

        if (distJugador<rangoAgro && Mathf.Abs(distJugador)>1)
        {
            PerseguirJugador();
            anim.SetFloat("Velocidad", 1);
            anim.SetBool("Atacar", false);
        }

        else if(Mathf.Abs(distJugador)<1)
        {
           anim.SetBool("Atacar", true);
        }

        else
        {
           NoPerseguir();
           anim.SetFloat("Velocidad", 0);
        }
    }

    private void NoPerseguir()
    {
        rb2d.velocity = Vector2.zero;
    }

    private void PerseguirJugador()
    {

             //Otra forma persecución

        DistEntre = player.position.x - transform.position.x;
        VelocidadMov = VelocidadMov * DistEntre;
        
        if(transform.position.x < player.position.x && !miraDerecha)
        {
            rb2d.velocity = new Vector2(VelocidadMov, 0f);
            Flip();
        }


        else if(transform.position.x > player.position.x && miraDerecha)
        {
            rb2d.velocity = new Vector2(-VelocidadMov, 0f);
            Flip();
        }

        else if(!miraDerecha)
        {
            rb2d.velocity = new Vector2(-VelocidadMov, 0f);
        }

         else if(miraDerecha)
        {
            rb2d.velocity = new Vector2(VelocidadMov, 0f);
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


