using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flecha : MonoBehaviour
{
    Rigidbody2D rb2d;
    controlArmas controlArmas;
    Collider2D Collider2D;

    [SerializeField] private float tiempoFlecha;
    [SerializeField] private float daño;

    private  Quaternion ultimaRotacion;
    private Animator animator;

    [SerializeField] private GameObject flechaVacia;

    void Start()
    {
        Collider2D = GetComponent<Collider2D>();
        rb2d = GetComponent<Rigidbody2D>();
        controlArmas = GameObject.FindGameObjectWithTag("Player").GetComponent<controlArmas>();
    }

    private void FixedUpdate()
    {
        Destroy(gameObject, tiempoFlecha);
    }     

    private void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemigo")) {
            other.gameObject.GetComponent<vidaEnemiga>().Golpe(daño);
        }
        else
        {
            ultimaRotacion = Quaternion.Euler(0, 0, transform.eulerAngles.z);
            GameObject flechaSuelta = Instantiate(flechaVacia, transform.position, ultimaRotacion);            
        }
            Destroy(gameObject);
    }
}