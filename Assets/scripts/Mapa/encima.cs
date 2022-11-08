using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class encima : MonoBehaviour
{ 
    vidaEnemiga vidaEnemiga;
    private int spawn;
    private Animator animator;
    private int i = 0;
    public int hijosContador = 0;
    public int contadorMuertos;
    public bool encierro = false;
    public bool accion = false;
    public List<Transform> enemigos;
    
    void Awake()
    {
        StartCoroutine(ConfigurarPuertasYEnemigosInicio(1f));
    }   
    void start(){
        vidaEnemiga =FindObjectOfType<vidaEnemiga>();
    }

    public IEnumerator ConfigurarPuertasYEnemigosInicio(float tiempoMargen)
    {
        yield return new WaitForSeconds(tiempoMargen);

        foreach (Transform child in transform) {
            if (!child.name.Contains("Point"))
            {
                Debug.Log(child);   
            }

            if (child.GetComponent<spawnEnemigos>() != null)
            {
                enemigos.Add(child.transform);
                Debug.Log("enemigos: " + enemigos.Count);                    
            }
            else if (child.childCount > 0)
            {
                var child2 = child.GetChild(0);
                if (child2.name == "puerta(Clone)" ||  child2.name == "puerta izq(Clone)" || child2.name == "puerta arriba(Clone)" || child2.name == "puerta abajo(Clone)")
                {
                    animator = child2.GetComponent<Animator>();
                    animator.SetBool("puertaOpen",true);
                }                
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if ((other.CompareTag("Player"))) {
            Debug.Log("enemigos: "+enemigos.Count);
            foreach (var spawn in enemigos) {
                if (spawn.childCount > 0)
                {
                    var enemigo = spawn.GetChild(0);
                    if (enemigo.CompareTag("Enemigo"))          //pregunta si hay enemigos entre los hijos de la habitacion y los cuenta
                    {
                        hijosContador++;
                    }
                }
            }
            Debug.Log("hijosCONTADOR: "+hijosContador);
            if(hijosContador!=0)
            {
                encierro = true;
                accion = true;
            
            
            foreach (Transform child in transform) {
                if (child.childCount > 0)
                {
                    var child2 = child.GetChild(0);
                    if (child2.name == "puerta(Clone)" ||  child2.name == "puerta izq(Clone)" || child2.name == "puerta arriba(Clone)" || child2.name == "puerta abajo(Clone)")
                    {
                        animator = child2.GetComponent<Animator>();
                        animator.SetTrigger("encierro");
                    }                    
                }
            }
            }
            Debug.Log(hijosContador);
        }
    }
    private void Update()
    {
        
        foreach (var spawn in enemigos) {
                if (spawn.childCount > 0)
                {
                    var enemigo = spawn.GetChild(0);
                    var scriptEnemigo= enemigo.GetComponent<vidaEnemiga>();
                    if(scriptEnemigo.muerto)
                    {
                        contadorMuertos++;
                        Debug.Log("el contador es de: "+contadorMuertos);
                    }
                }
            }
        if(hijosContador==0 && accion)
        {
            foreach (Transform child in transform) {
                if (child.childCount > 0)
                {
                    var child2 = child.GetChild(0);
                    if (child2.name == "puerta(Clone)" ||  child2.name == "puerta izq(Clone)" || child2.name == "puerta arriba(Clone)" || child2.name == "puerta abajo(Clone)")
                    {
                        animator = child2.GetComponent<Animator>();
                        animator.SetBool("puertaOpen",false);
                        animator.SetBool("enemigosMuertos",true);
                    }                    
                }
            }
        }
        
       
        
    }
}