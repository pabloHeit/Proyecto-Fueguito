using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class encima : MonoBehaviour
{ 
    private int spawn;
    private Animator animator;
    private int i = 0;
    public int hijosContador = 0;
    public bool encierro;
    void Awake()
    {
        
        StartCoroutine(ConfigurarPuertasInicio(1f));

    }

    

    public IEnumerator ConfigurarPuertasInicio(float tiempoMargen)
    {
        yield return new WaitForSeconds(tiempoMargen);

        foreach (Transform child in transform) {
            var child2 = child.GetChild(0);
            if (child2.name == "puerta(Clone)" ||  child2.name == "puerta izq(Clone)" || child2.name == "puerta arriba(Clone)" || child2.name == "puerta abajo(Clone)")
            {
                animator = child2.GetComponent<Animator>();
                animator.SetBool("puertaAbierta",true);
            }
        }        
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if ((other.CompareTag("Player"))) {
              
       
        
            //falta preguntar si hay bichos
            encierro=true;
           foreach (Transform child in transform) {
            if (child.CompareTag("Enemigo"))
        {
            hijosContador++;
        }
                var child2 = child.GetChild(0);
                if (child2.name == "puerta(Clone)" ||  child2.name == "puerta izq(Clone)" || child2.name == "puerta arriba(Clone)" || child2.name == "puerta abajo(Clone)")
                {
                    animator = child2.GetComponent<Animator>();
                    animator.SetTrigger("encierro");

                }
            }
            Debug.Log(hijosContador);
        }
    }
    private void Update()
    {
        
            
        
        
       
        
    }
}