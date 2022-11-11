using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class N1_IA : MonoBehaviour 
{
    movimientoEnemigos movimientoEnemigos;
    controladorVidas controladorVidas;
    Animator anim;
    Rigidbody2D rb;
    AudioSource audioSource;
   
    private Transform player;
   
    [SerializeField] float cooldown;
    [SerializeField] private float TiempoBala;
    private float ultimoGolpe;
   
    public GameObject BalaEnemiga;
    private float VelocidadB = 10f;

    [SerializeField] private Transform disparador;    
    [SerializeField] private AudioClip sonidoDisparo;

    void Start()
    {
        movimientoEnemigos = this.gameObject.GetComponent<movimientoEnemigos>();
        anim = GetComponent<Animator>();
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = this.GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        
    }
    
    private void DisparoAgua()
    {
        audioSource.PlayOneShot(sonidoDisparo);
        Vector3 lookAtDirection = player.position - disparador.position;
        lookAtDirection.z = 0.0f;
        disparador.right = lookAtDirection;

        GameObject balaene = Instantiate(BalaEnemiga, disparador.position, disparador.rotation);
        
        balaene.GetComponent<Rigidbody2D>().AddForce(disparador.right * VelocidadB, ForceMode2D.Impulse);
    } 
}