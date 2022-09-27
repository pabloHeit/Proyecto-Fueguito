using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaEnemiga : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    [SerializeField] public float vida;
    [SerializeField] public float vidaInicial;

    void Start()
    {
        anim = this.GetComponent<Animator>();
        vidaInicial = vida;
    }

    public void Golpe()
    {
        vida--;
        
        if(vida <= 0) {
            anim.SetTrigger("Morir");
        }
        
        anim.SetTrigger("Dañado");
    }

    private void Muerte()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "balas") {
            Golpe();
        }
    }
}