using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controladorVidas : MonoBehaviour
{
    [SerializeField] private GameObject ojos;
    private movimientoJugador movimientoJugador;
    [SerializeField] public float vidaJugador;
    [SerializeField] private float vidaMaxima;
    private Animator animator;
    //[SerializeField] private GameObject bufanda;
    [SerializeField] private float tiempoPerdidaControl;
    [SerializeField] private float tiempoInmunidad;
    AudioSource audioGolpe;
    [SerializeField] private Image barraDeVida;
    public event EventHandler OnMuerto;
    private bool dying;
    [SerializeField] private GameObject tumba;

    void Start()
    {
        animator = GetComponent<Animator>();
        movimientoJugador= GetComponent<movimientoJugador>();
        audioGolpe = GetComponent<AudioSource>();
        barraDeVida.fillAmount = (vidaJugador / vidaMaxima);
    }
    void Update()
    {
        if (vidaJugador<=0 && !dying)
        {
            Muerte();         
        } 
    }
    public void Muerte()
    {
        dying = true;
        OnMuerto?.Invoke(this, EventArgs.Empty);        
        animator.SetBool("Dead", true);
        StartCoroutine(PerderControl(2));
        Destroy(gameObject,1.5f);
        Instantiate(tumba, transform.position, Quaternion.identity);
    }

    public void TomarDaño(float daño)
    {
        //audioGolpe.Play();
        vidaJugador -= daño;
        animator.SetBool("Idle",false);
        animator.SetTrigger("Dañado");
        barraDeVida.fillAmount = (vidaJugador / vidaMaxima);
        StartCoroutine(DesactivarColision(0.5f));

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
