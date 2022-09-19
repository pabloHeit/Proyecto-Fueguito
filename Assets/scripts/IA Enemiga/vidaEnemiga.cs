using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaEnemiga : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;

    [SerializeField] private float vida;

    void Start()
    {
        anim = this.GetComponent<Animator>();
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