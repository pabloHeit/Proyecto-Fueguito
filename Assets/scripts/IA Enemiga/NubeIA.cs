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
    
    [SerializeField] private float tiempoDisparo;

    private bool contadorTiempo = false;

    private Vector3 lookAtDirection;

    void Start()
    {
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
        movimientoEnemigos = this.GetComponent<movimientoEnemigos>();
        contadorTiempo = false;
    }

    void Awake()
    {
        GameObject laserSpawn = Instantiate(laser, transform.position, Quaternion.identity);
        DisparoLinea = laserSpawn.GetComponent<LineRenderer>();
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

    private void DisparoAgua()
    {
        GameObject balaene = Instantiate(BalaEnemiga, disparador.position, disparador.rotation);
        Rigidbody2D rb = balaene.GetComponent<Rigidbody2D>();
        rb.AddForce(disparador.right * VelocidadB, ForceMode2D.Impulse);
    }

    private void DisparoNube()
    {
        RaycastHit2D raycastHit2D = Physics2D.Raycast(disparador.position, lookAtDirection, rango);
        if (raycastHit2D){
            // Debug.Log($"hola 1 : {raycastHit2D.transform.name}");
           if(raycastHit2D.transform.CompareTag("Player")) {
                // Debug.Log($"hola 2");
                Debug.DrawRay(disparador.position, objetivo.position, Color.red);
                controladorVidas.TomarDamage(dañobala);
                StartCoroutine(GenerarLinea(raycastHit2D.point));
            }
            anim.SetTrigger("Descanso");
        }       
    }

    IEnumerator GenerarLinea(Vector3 objeto) 
    {
        DisparoLinea.enabled = true;
        DisparoLinea.SetPosition(0, disparador.position);
        DisparoLinea.SetPosition(1, objeto);
        yield return new WaitForSeconds(tiempoDisparo);
        DisparoLinea.enabled = false;
    }
}