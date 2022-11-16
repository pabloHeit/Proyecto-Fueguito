using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class encima : MonoBehaviour
{
    AudioSource audioSource;
    vidaEnemiga vidaEnemiga;
    cambioDeMusica cambioDeMusica;

    public Transform[] startingPositions;
    public GameObject[] cofre;
    private int spawn;
    private Animator animator;
    public int hijosContador = 0;
    public int contadorMuertos;
    public bool encierro = false;
    public bool accion = false;
    public List<Transform> spawnEnemigos;
    public List<GameObject> enemigos;
    public List<BoxCollider2D> puertaColliders;

    [SerializeField] private AudioClip puertaAbriendose;
    [SerializeField] private AudioClip puertaCerrandose;

    public int enemigosReales = 0;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        cambioDeMusica = FindObjectOfType<cambioDeMusica>();        
        StartCoroutine(ConfigurarPuertasYEnemigosInicio(1f));
    }

    void start() {
        vidaEnemiga = FindObjectOfType<vidaEnemiga>();
    }

    private void Update()
    {
        if(accion) {
            if (ContarEnemigosVivos() == 0 && encierro) {
                FinalizarBatalla();
                accion = false;
            }
        }
    }

    public IEnumerator ConfigurarPuertasYEnemigosInicio(float tiempoMargen)
    {
        yield return new WaitForSeconds(tiempoMargen);

        foreach (Transform child in transform) {

            if (child.GetComponent<spawnEnemigos>() != null)
            {
                spawnEnemigos.Add(child.transform);
            }
            else if (child.childCount > 0)
            {
                var child2 = child.GetChild(0);
                if (child2.name == "puerta(Clone)" ||  child2.name == "puerta izq(Clone)" || child2.name == "puerta arriba(Clone)" || child2.name == "puerta abajo(Clone)")
                {
                    animator = child2.GetComponent<Animator>();
                    animator.SetBool("puertaOpen", true);
                }
            }
        }
    }
    
    private void OnTriggerEnter2D(Collider2D other) {
        if ((other.CompareTag("Player"))) 
        {
            if(ContarEnemigosInicio() > 0)
            {
                IniciarBatalla();
            }            
        }
    }  

    private int ContarEnemigosInicio()
    {
        foreach (var spawn in spawnEnemigos) {
            if (spawn.childCount > 0)
            {
                var enemigo = spawn.GetChild(0);
                if (enemigo.CompareTag("Enemigo"))
                {
                    enemigos.Add(enemigo.gameObject);
                    hijosContador++;
                }
            }
        }
        return hijosContador;
    }
    
    public int ContarEnemigosVivos()
    {
        enemigos.RemoveAll(enemigo => enemigo == null);
        enemigosReales = enemigos.Count;
        return enemigosReales;
    }

    public void IniciarBatalla()
    {
        cambioDeMusica.ReproducirMusica_Pelea();
        audioSource.PlayOneShot(puertaCerrandose);
        encierro = true;
        accion = true;

        CerrarPuertas();
    }

    public void FinalizarBatalla()
    {
        audioSource.PlayOneShot(puertaAbriendose);
        cambioDeMusica.ReproducirMusica_Tranqui();
        encierro = false;

        SpawnearCofre();
        AbrirPuertas();

        Destroy(this);
    }

    private void SpawnearCofre() {
        int rand = Random.Range(0, startingPositions.Length);
        Vector2 cofrePos = new Vector2(startingPositions[rand].position.x, startingPositions[rand].position.y) ;
        Instantiate(cofre[0], cofrePos, Quaternion.identity);
    }

    private void CerrarPuertas() {
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

    private void AbrirPuertas() {
        foreach (Transform child in transform) {
            if (child.childCount > 0)
            {
                var child2 = child.GetChild(0);
                if (child2.name == "puerta(Clone)" ||  child2.name == "puerta izq(Clone)" || child2.name == "puerta arriba(Clone)" || child2.name == "puerta abajo(Clone)")
                {
                    animator = child2.GetComponent<Animator>();
                    animator.SetBool("puertaOpen",false);
                    animator.SetBool("enemigosMuertos",true);

                    foreach (var puertaCollider in puertaColliders)
                    {
                        Destroy(puertaCollider);
                    }
                }
            }
        }
    }
}