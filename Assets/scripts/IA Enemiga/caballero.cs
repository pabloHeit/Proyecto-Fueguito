using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class caballero : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Rigidbody2D rb;    
    Animator anim;
    
    controladorVidas controladorVidas;
    movimientoEnemigos movimientoEnemigos;

    [SerializeField] private GameObject enemigo;

    [SerializeField] private float daño;
    [SerializeField] private float radioAtaque;
   
    private void Start()
    {
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
        movimientoEnemigos = this.gameObject.GetComponent<movimientoEnemigos>();
    }

    private void atacar()
    {
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, radioAtaque);
        foreach (Collider2D colisionador in objetos){
            if (colisionador.CompareTag("Player")){
                controladorVidas.TomarDamage(daño);
            }
        }
        movimientoEnemigos.atacando = false;
    }

    private void SpawnEnemigo()
    {
        Instantiate(enemigo, transform.position, transform.rotation);
    }

    void OnDrawGizmosSelected()
    {        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioAtaque);
    }
}