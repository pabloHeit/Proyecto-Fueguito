using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class N1_IA : MonoBehaviour 
{
    movimientoEnemigos movimientoEnemigos;
    Animator anim;
    controladorVidas controladorVidas;
    Rigidbody2D rb;
   
    private Transform player;
   
    [SerializeField] float cooldown;
    [SerializeField] private float TiempoBala;
    private float ultimoGolpe;
   
    public GameObject BalaEnemiga;
    private BalaAgua BalaAgua;
    [SerializeField] private GameObject efectoImpacto;
    private float VelocidadB = 10f;

    [SerializeField] private Transform disparador;

    

    void Start()
    {
        movimientoEnemigos = this.gameObject.GetComponent<movimientoEnemigos>();
        anim = GetComponent<Animator>();
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();
        BalaAgua = GetComponent<BalaAgua>();  
    }
    
    private void DisparoAgua()
    {
        Vector3 lookAtDirection = player.position - disparador.position;
        lookAtDirection.z = 0.0f;
        disparador.right = lookAtDirection;

        GameObject balaene = Instantiate(BalaEnemiga, disparador.position, disparador.rotation);
        Rigidbody2D rb = balaene.GetComponent<Rigidbody2D>();
        rb.AddForce(disparador.right * VelocidadB, ForceMode2D.Impulse);
    } 
}