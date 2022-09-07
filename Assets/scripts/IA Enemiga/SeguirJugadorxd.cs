using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SeguirJugadorxd : MonoBehaviour
{
    [SerializeField] private Transform objetivo;
    private NavMeshAgent navMeshAgent;
    [SerializeField] public int vidaEnemiga;
    [SerializeField] private GameObject enemigo;
   
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
    }

    private void Update()
    {
        navMeshAgent.SetDestination(objetivo.position);
    }

    public void Golpe()
   {
       vidaEnemiga = vidaEnemiga - 1;
       if(vidaEnemiga == 0)
       {
       SpawnEnemigo();
       Destroy(gameObject);
       }
   }


   private void SpawnEnemigo()
   {
        Instantiate(enemigo, transform.position, transform.rotation);
        Instantiate(enemigo, transform.position, transform.rotation);
   }

    private void OnTriggerEnter2D(Collider2D other) {
    if (other.gameObject.tag == "balas")
    {
        Golpe();
    }
   }
}

