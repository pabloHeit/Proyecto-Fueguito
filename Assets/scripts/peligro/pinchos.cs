using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinchos : MonoBehaviour
{
    AudioSource audioSource;
    Animator Animator;
    [SerializeField] private int knockback;
    [SerializeField] private float daño;
    [SerializeField] private AudioClip sonidoPinchar;


    public bool puedePinchar ;
    private void Start() {
        audioSource = GetComponent<AudioSource>();
        puedePinchar = true;
        Animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if ((other.CompareTag("Player") || other.CompareTag("Enemigo")) && puedePinchar) {
            Pinchar(other);
        }
    }
    
    void OnTriggerStay2D(Collider2D other) {
        if ((other.CompareTag("Player") || other.CompareTag("Enemigo")) && puedePinchar) {
            Pinchar(other);
        }
    }

    private void Pinchar(Collider2D other) 
    {
        audioSource.PlayOneShot(sonidoPinchar);
        Collider2D[] personajes = Physics2D.OverlapBoxAll(transform.position, new Vector3(1,1,0), 0);
        foreach (Collider2D colisionador in personajes) {
            Rigidbody2D rb2D = colisionador.GetComponent<Rigidbody2D>();
            if (rb2D != null) {
                Animator.SetTrigger("Pinchar");
                Vector2 direccion = other.transform.position - transform.position;
                // rb2D.AddForce(direccion.normalized * knockback);
                if (other.CompareTag("Player")) {
                    other.GetComponent<controladorVidas>().TomarDamage(daño);
                }
                else {
                    if (other.GetComponent<vidaEnemiga>().puedeColisionar) {
                        StartCoroutine(other.GetComponent<vidaEnemiga>().DesactivarColision(0.5f));                            
                        other.GetComponent<vidaEnemiga>().Golpe();
                    }
                }
            }
        }       
    }
}