using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granada : MonoBehaviour
{
    [SerializeField] private float tiempoGranada;
    [SerializeField] private GameObject explosionEfecto;
    [SerializeField] private float radio;
    [SerializeField] private float fuerzaExplosion;

    private  Quaternion ultimaRotacion;
    private Animator animator;
    private Transform _t;
    private float tiempoGranadaExplosion = 0.65f;
    private float tiempoGranadaContador;
    SpriteRenderer sprite;
    private bool chocarBool = false; 

    private void Start(){

        sprite = GetComponent<SpriteRenderer>();
    	animator = GetComponent<Animator>();
        _t = GetComponent<Transform>();
        tiempoGranadaContador = Time.time + tiempoGranada;
    }

    private void FixedUpdate(){
        if (tiempoGranadaContador < Time.time){           
            Explosion();
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        chocarBool = !chocarBool;
        sprite.flipX = chocarBool;
    }

    

    private void Explosion()
    {
        Collider2D[] personajes = Physics2D.OverlapCircleAll(_t.position, radio);
        foreach (Collider2D colisionador in personajes)
        {
            Rigidbody2D rb2D = colisionador.GetComponent<Rigidbody2D>();
            if (rb2D != null)
            {
                Vector2 direccion = colisionador.transform.position - _t.position;
                float distancia = 1 + direccion.magnitude;
                float fuerzaFinal = fuerzaExplosion / distancia;
                rb2D.AddForce(direccion * fuerzaFinal);
            }
            
        }
        ultimaRotacion = Quaternion.Euler(0,0, _t.eulerAngles.z);
        GameObject explosion = Instantiate(explosionEfecto, _t.position, ultimaRotacion);
        //DañarEnemigo();
        Destroy(explosion, tiempoGranadaExplosion);
        Destroy(gameObject);

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}