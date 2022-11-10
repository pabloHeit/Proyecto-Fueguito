using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class encima : MonoBehaviour
{ 
    public Transform[] startingPositions;
    public GameObject[] cofre;
    vidaEnemiga vidaEnemiga;
    private int spawn;
    private Animator animator;
    private int i = 0;
    public int hijosContador = 0;
    public int contadorMuertos;
    public bool encierro = false;
    public bool accion = false;
    public List<Transform> spawnEnemigos;
    public List<GameObject> enemigos;
    public List<BoxCollider2D> puertaColliders;
    
    public int enemigosReales = 0;
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

            if (child.GetComponent<spawnEnemigos>() != null)
            {
                spawnEnemigos.Add(child.transform);
                Debug.Log("spawnEnemigos: " + spawnEnemigos.Count);                    
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
            Debug.Log("spawnEnemigos: "+spawnEnemigos.Count);
            foreach (var spawn in spawnEnemigos) {
                if (spawn.childCount > 0)
                {
                    var enemigo = spawn.GetChild(0);
                    if (enemigo.CompareTag("Enemigo"))          //pregunta si hay spawnEnemigos entre los hijos de la habitacion y los cuenta
                    {
                        enemigos.Add(enemigo.gameObject);
                        hijosContador++;
                        Debug.Log(enemigos);
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
                            child2.gameObject.AddComponent(typeof(BoxCollider2D));
                            var collider = child2.GetComponent<BoxCollider2D>();
                            puertaColliders.Add(collider);
                        }                    
                    }
                }
            }
            Debug.Log(hijosContador);
        }
    }
    private void Update()
    {
        if(accion)
        {
            enemigos.RemoveAll(s => s == null);
            enemigosReales = enemigos.Count;
        }   
        
        if(enemigosReales == 0 && encierro)
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
                        encierro = false;
                        foreach (var puertaCollider in puertaColliders)
                        {
                            Destroy(puertaCollider);                            
                        }
                        int rand= Random.Range(0,startingPositions.Length);
                        Vector2 cofrePos =new Vector2(startingPositions[rand].position.x, startingPositions[rand].position.y) ;
                        Instantiate(cofre[0], cofrePos, Quaternion.identity);
                    }                    
                }
            }
        }
        
       
        
    }
}