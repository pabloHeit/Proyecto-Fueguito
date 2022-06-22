using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaControlador : MonoBehaviour
{
    private Animator animator;
   // private bool abierta = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {         
            animator.SetBool("puertaAbierta", true);
            //abierta= true;
        }            
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("puertaAbierta", false);
           // abierta = false;
        }
    }
}
