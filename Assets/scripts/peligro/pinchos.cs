using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pinchos : MonoBehaviour
{
    private controladorVidas controladorVidas;
    [SerializeField] private float knockback;
    private Animator Animator;
    private bool enPincho;
    private void Start() {
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
        Animator = GetComponent<Animator>();
    }
    private void Update(){
        if (enPincho)
        {
            Pinchar();
        }

    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            Pinchar();
        }
    }
    private void Pinchar()
    {
        enPincho = true;
        Animator.SetTrigger("Pinchar");
        controladorVidas.TomarDaño(0.5f);
        Rigidbody2D rb2D = controladorVidas.GetComponent<Rigidbody2D>();
        if (rb2D != null)
        {
            Vector2 direccion = controladorVidas.transform.position - transform.position;
            float distancia = 1 + direccion.magnitude;
            float fuerzaFinal = knockback / distancia;
            rb2D.AddForce(direccion * fuerzaFinal);
        }
    }
}
    

