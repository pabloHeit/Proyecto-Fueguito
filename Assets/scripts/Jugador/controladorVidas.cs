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

    [SerializeField] public float vidaJugador;
    [SerializeField] public float vidaMaxima;
    
    [SerializeField] private float tiempoPerdidaControl;
    [SerializeField] private float tiempoInmunidad;
    
    [SerializeField] private Image barraDeVida;

    [SerializeField] private GameObject tumba;

    private bool dying;

    void Start()
    {
        animator = GetComponent<Animator>();
        movimientoJugador = GetComponent<movimientoJugador>();
        audioGolpe = GetComponent<AudioSource>();
        ActualizarBarraVida();
    }

    void Update()
    {
        if (vidaJugador <= 0 && !dying) 
            Muerte();
    }
    
    private void ActualizarBarraVida(){
        barraDeVida.fillAmount = (vidaJugador / vidaMaxima);
    }

    public void Muerte()
    {        
        GameManager.Instance.UpdateGameState(GameState.Muerte);

        ActualizarBarraVida();
        dying = true;
        animator.SetBool("Dead", true);
        StartCoroutine(PerderControl(4));
        Destroy(gameObject,1.5f);
        Instantiate(tumba, transform.position, Quaternion.identity);
    }

    public void TomarDaño(float daño)
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
