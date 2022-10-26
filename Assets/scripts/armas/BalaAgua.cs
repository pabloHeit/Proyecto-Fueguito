using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaAgua : MonoBehaviour
{
    controladorVidas controladorVidas;
    Transform player;
    movimientoJugador movimientoJugador;
    AudioSource audioSource;

    [SerializeField] private float daño;
    [SerializeField] public bool ralentiza;

    [SerializeField] private float VelMov;
    [SerializeField] float cooldownVel;
    
    private float tiempoEfecto;
    [SerializeField] private GameObject efectoImpacto;

    [SerializeField] private AnimationClip clip;

    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
            movimientoJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<movimientoJugador>();   
        }
        tiempoEfecto = clip.length;
    }

    public void OnTriggerEnter2D(Collider2D other) {
      
        if(other.CompareTag("Player"))
        {            
            if (ralentiza) {
                movimientoJugador.realentizar(VelMov, cooldownVel); }
            controladorVidas.TomarDamage(daño);
        }
        
        GameObject efecto1 = Instantiate(efectoImpacto, transform.position, transform.rotation); 
        Destroy(efecto1, tiempoEfecto);
        Destroy(this.gameObject);
    }   
}