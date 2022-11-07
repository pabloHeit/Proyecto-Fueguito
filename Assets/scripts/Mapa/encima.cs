using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class encima : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("gol");
         foreach (Transform child in transform) {
            foreach (Transform child2 in transform) {
                Debug.Log(child2.name);
                if (child2.name == "puerta(Clone)" ||  child2.name == "puerta izq(Clone)" || child2.name == "puerta arriba(Clone)" || child2.name == "puerta abajo(Clone)")
                {
                    animator = child2.GetComponent<Animator>();
                    Debug.Log("gol2");
                    animator.SetBool("puertaAbierta",true);
                }
            }
    }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /* private void OnTriggerEnter2D(Collider2D other) {
        if ((other.CompareTag("Player"))) {
            Debug.Log("entro");
            //falta preguntar si hay bichos
           foreach (Transform child in transform) {
            foreach (Transform child2 in transform) {
                Debug.Log(child2.name);
                if (child2.name == "puerta(Clone)" ||  child2.name == "puerta izq(Clone)" || child2.name == "puerta arriba(Clone)" || child2.name == "puerta abajo(Clone)")
                {
                    animator = child2.GetComponent<Animator>();
                    animator.SetTrigger("encierro");
                }
            }
    }

            
        }
    } */
}
