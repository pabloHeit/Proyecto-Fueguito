using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinchos : MonoBehaviour
{
    Animator Animator;

    [SerializeField] private int knockback;
    [SerializeField] private float daño;

    [SerializeField] private float cooldownPinchar = 3f;
    [SerializeField] private float cooldownPincharContador;

    [SerializeField] private float tiempoPinchar = 1f;

    public bool puedePinchar;

    private void Start() {
        puedePinchar = true;
        Animator = GetComponent<Animator>();
    }

    private void Update() {
        if (cooldownPincharContador < Time.time && puedePinchar == false)
        {
            puedePinchar = true;            
        }        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if ((other.CompareTag("Player") || other.CompareTag("Enemigo")) && puedePinchar) {
            cooldownPincharContador = cooldownPinchar + Time.time;
            puedePinchar = false;
            StartCoroutine(Pinchar(other));
        }
    }
    
    void OnTriggerStay2D(Collider2D other) {
        if ((other.CompareTag("Player") || other.CompareTag("Enemigo")) && puedePinchar) {
            StartCoroutine(Pinchar(other));
        }
    }

    private IEnumerator Pinchar(Collider2D other) 
    {
        yield return new WaitForSeconds(tiempoPinchar);

        Animator.SetTrigger("Pinchar");
        Collider2D[] personajes = Physics2D.OverlapBoxAll(transform.position, new Vector3(1,1,0), 0);
        foreach (Collider2D colisionador in personajes) {
            Rigidbody2D rb2D = colisionador.GetComponent<Rigidbody2D>();
            if (rb2D != null) {
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