using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class subdito_normie : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    Rigidbody2D rb;    
    Animator anim;
    AudioSource audioSource;
    
    controladorVidas controladorVidas;
    movimientoEnemigos movimientoEnemigos;

    [SerializeField] private float daño;
    [SerializeField] private float radioAtaque;
   
    [SerializeField] private AudioClip sonidoAtaque;

    private void Start()
    {
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
        movimientoEnemigos = this.gameObject.GetComponent<movimientoEnemigos>();
        audioSource = GetComponent<AudioSource>();
    }

    private void atacar()
    {
        audioSource.PlayOneShot(sonidoAtaque);
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, radioAtaque);
        foreach (Collider2D colisionador in objetos){
            if (colisionador.CompareTag("Player")){
                controladorVidas.TomarDamage(daño);
            }
        }
        movimientoEnemigos.atacando = false;
    }

    void OnDrawGizmosSelected()
    {        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioAtaque);
    }
}