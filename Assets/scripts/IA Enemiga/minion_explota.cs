using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class minion_explota : MonoBehaviour
{
    movimientoEnemigos movimientoEnemigos;
    controladorVidas controladorVidas;

    private Transform player;

    private bool explotando = false;

    [SerializeField] private float tiempoMinion;
    private float tiempoMinionContador;

    [SerializeField] private float radio;
    [SerializeField] private float daño;

    [SerializeField] private GameObject explosionEfecto;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
        movimientoEnemigos = this.gameObject.GetComponent<movimientoEnemigos>();
    }

    void IniciarExplosion()
    {
        tiempoMinionContador = Time.time + tiempoMinion;
        movimientoEnemigos.atacando = true;
        explotando = true;
    }

    void Update()
    {
        if (explotando && tiempoMinionContador < Time.time) {
            Explosion();
        }        
    }

    private void Explosion()
    {
        Collider2D[] personajes = Physics2D.OverlapCircleAll(transform.position, radio);

        foreach (Collider2D colisionador in personajes)
        {
            Rigidbody2D rb2D = colisionador.GetComponent<Rigidbody2D>();
            if (colisionador.gameObject.tag == "Player")
            {
                Vector2 direccion = colisionador.transform.position - transform.position;
                controladorVidas.TomarDamage(daño);
                Destroy(gameObject);
                break;
            }
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}