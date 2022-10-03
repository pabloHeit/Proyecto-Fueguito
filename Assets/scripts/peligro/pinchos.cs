using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinchos : MonoBehaviour
{
    controladorVidas controladorVidas;
    movimientoJugador movimientoJugador; 

    [SerializeField] private int knockback;
    private Animator Animator;
    [SerializeField] private float daño;
    private void Start() {
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
        movimientoJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<movimientoJugador>();
        Animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            Pinchar();
        }
    }
    private void Pinchar(){
        movimientoJugador.knockbackPlayer(transform.position, knockback);
        Animator.SetTrigger("Pinchar");
        controladorVidas.TomarDamage(daño);
    }
}
    

