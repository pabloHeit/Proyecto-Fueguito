using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controladorVidas : MonoBehaviour
{
    movimientoJugador movimientoJugador;
    Animator animator;
    AudioSource audioGolpe;
    controlArmas controlArmas;

    [SerializeField] public float vidaJugador;
    [SerializeField] public float vidaMaxima;
    
    [SerializeField] private float tiempoPerdidaControl;
    [SerializeField] private float tiempoInmunidad;
    
    [SerializeField] private Image barraDeVida;

    [SerializeField] private GameObject ojos;

    private bool dying;

    void Start()
    {
        movimientoJugador = GetComponent<movimientoJugador>();
        controlArmas = GetComponent<controlArmas>();
        animator = GetComponent<Animator>();
        audioGolpe = GetComponent<AudioSource>();
        ActualizarBarraVida();
    }

    void Update()
    {
        if (vidaJugador <= 0 && !dying) 
        {
            animator.SetBool("Muriendo", true);
            dying = true;
            ActualizarBarraVida();
            animator.SetTrigger("Dead");
            Destroy(ojos);
            GameManager.EnableInput = false;

            foreach (Transform child in transform) {
                Destroy(child.gameObject);
            }
            Destroy(controlArmas);         
        }
    }
    
    private void ActualizarBarraVida(){
        barraDeVida.fillAmount = (vidaJugador / vidaMaxima);
    }

    public void Muerte()
    {        
        Destroy(gameObject);
        GameManager.Instance.UpdateGameState(GameState.Muerte);
    }

    public void TomarDamage(float daño = 10)
    {
        //audioGolpe.Play();
        vidaJugador -= daño;
        ActualizarBarraVida();
        animator.SetTrigger("Dañado");
        StartCoroutine(DesactivarColision(0.5f));
    }

    public void TomarVida(float vidaEntrante) //cambiar a int si usamos bloques de vida
    {
        float vidaFaltante = (vidaMaxima - vidaJugador) ;

        if (vidaFaltante > vidaEntrante)
            vidaJugador += vidaEntrante;
        else
            vidaJugador = vidaMaxima;

        ActualizarBarraVida();
        //animator.SetTrigger("Curacion");
    }

    public void Resucitar()
    {
        //
    }

    public IEnumerator DesactivarColision(float TiempoInmunidad)
    {
        Physics2D.IgnoreLayerCollision(3,6,true);
        yield return new WaitForSeconds(TiempoInmunidad);
        Physics2D.IgnoreLayerCollision(3,6,false);
    }
    
    public IEnumerator PerderControl(float TiempoPerdidaControl)
    {
        movimientoJugador.sePuedeMover = false;
        yield return new WaitForSeconds(TiempoPerdidaControl);
        movimientoJugador.sePuedeMover = true;
    }

}
