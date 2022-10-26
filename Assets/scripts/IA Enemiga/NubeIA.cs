using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NubeIA : MonoBehaviour
{
    Animator anim;
    Transform player;
    BalaAgua BalaAgua;
    movimientoEnemigos movimientoEnemigos;
    controladorVidas controladorVidas;


    [SerializeField] float cooldown;
    private float VelocidadB = 10f;
    private float ultimoGolpe;

    public GameObject BalaEnemiga;
    public GameObject laser;

    [SerializeField] private Transform disparador;
    
    private bool enojo = true;

    private float contadorTime;

    [SerializeField] private float dañobala;

    [SerializeField] private LineRenderer DisparoLinea;
    [SerializeField] private BoxCollider2D caja;
    
    [SerializeField] private float tiempoDisparo;

    private bool contadorTiempo = false;

    private Vector3 lookAtDirection;

    void Start()
    {
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
        anim = this.GetComponent<Animator>();       
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>(); 
        movimientoEnemigos = this.GetComponent<movimientoEnemigos>();
        contadorTiempo = false;
    }

    void Awake()
    {
        GameObject laserSpawn = Instantiate(laser, transform.position, Quaternion.identity);
        DisparoLinea = laserSpawn.GetComponent<LineRenderer>();
        caja = laserSpawn.GetComponent<BoxCollider2D>();
    }

    void Update() 
    {    
        if(controladorVidas != null && movimientoEnemigos.enemigoAct)
        {
            lookAtDirection = player.position - disparador.position;
            Debug.DrawRay(disparador.position, lookAtDirection, Color.white);
            lookAtDirection.z = 0.0f;
            disparador.right = lookAtDirection;
            
            if(!contadorTiempo) {
                contadorTime = Time.time + 10;
                contadorTiempo = true;
            }

            if (contadorTiempo) {
                if(Time.time > contadorTime) {
                    anim.SetTrigger("Rayo");
                    contadorTiempo = false;
                }
            }        
        }
    }

    public void DisparoAgua()
    {
        GameObject balaene = Instantiate(BalaEnemiga, disparador.position, disparador.rotation);
        // balaAgua = balaene.GetComponent<BalaAgua>();
        // >balaAgua.realentiza = true;
        Rigidbody2D rb = balaene.GetComponent<Rigidbody2D>();
        rb.AddForce(disparador.right * VelocidadB, ForceMode2D.Impulse);
    }

    public void DisparoNube()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(disparador.position, lookAtDirection, movimientoEnemigos.distanciaAtaque, 10);
        if (raycastHit2D) {
           if(raycastHit2D.transform.CompareTag("Player")) {
                controladorVidas.TomarDamage(dañobala);
                StartCoroutine(GenerarLinea(raycastHit2D.point));
            }
        }       
    }

    IEnumerator GenerarLinea(Vector3 objeto) 
    {
        caja.enabled = true;
        DisparoLinea.enabled = true;
        DisparoLinea.SetPosition(0, disparador.position);
        DisparoLinea.SetPosition(1, objeto);
        yield return new WaitForSeconds(tiempoDisparo);
        DisparoLinea.enabled = false;
        caja.enabled = true;
    }
}