using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class minion_explota : MonoBehaviour
{
    controladorVidas controladorVidas;
    [SerializeField] public int vidaEnemiga;
    [SerializeField] private float tiempoMinion;
    [SerializeField] private GameObject explosionEfecto;
    private Transform objetivo;
    [SerializeField] private float radio;
    private float distJugador;
    private Transform player;
    private Vector2 movement;

    private bool explotando = false;
    private NavMeshAgent navMeshAgent;
    private float tiempoMinionContador;

    [SerializeField] private float daño;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        objetivo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
    }
    private void Awake() {
        objetivo = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update(){
        distJugador = Vector2.Distance(transform.position, player.position);
        // Debug.Log(distJugador);
        navMeshAgent.SetDestination(objetivo.position);

        if (tiempoMinionContador < Time.time && explotando){           
            Explosion();   
        }

        if (Mathf.Abs(distJugador) <= 1 && !explotando){
            tiempoMinionContador = Time.time + tiempoMinion;
            explotando = true;
        } 
    }
    private void Explosion()
    {
    Vector3 direction = player.position - transform.position;
      float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
      direction.Normalize();
      movement = direction;

     
        
        Collider2D[] personajes = Physics2D.OverlapCircleAll(transform.position, radio);

        foreach (Collider2D colisionador in personajes)
        {
            Rigidbody2D rb2D = colisionador.GetComponent<Rigidbody2D>();
            if (colisionador.gameObject.tag == "Player")
            {
                Vector2 direccion = colisionador.transform.position - transform.position;
                Debug.Log("PUM");
                controladorVidas.TomarDamage(daño);
                Destroy(gameObject);
                break;
            }
        }

        // GameObject explosion = Instantiate(explosionEfecto, transform.position, ultimaRotacion);
        //  IA2 enemigo = explosion.GetComponent<IA2>(); 
        //   if(enemigo != null)
        //    {
        //     enemigo.Golpe();
        //    } 

     

    }

    public void Golpe()
   {
       vidaEnemiga = vidaEnemiga - 1;
       if(vidaEnemiga == 0)
       Destroy(gameObject);
   }

    private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.tag == "balas")
    {
        Golpe();
    }
   }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }
}
