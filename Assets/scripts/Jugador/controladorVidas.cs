using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controladorVidas : MonoBehaviour
{
    private movimientoJugador movimientoJugador;
    [SerializeField] public float vidaJugador;
    [SerializeField] public float vidaMaxima;
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
        movimientoJugador = GetComponent<movimientoJugador>();
        audioGolpe = GetComponent<AudioSource>();
        barraDeVida.fillAmount = (vidaJugador / vidaMaxima);
    }
    void Update()
    {
        if (vidaJugador<=0 && !dying) Muerte();
        else barraDeVida.fillAmount = (vidaJugador / vidaMaxima);
    }

    public void Muerte()
    {
        barraDeVida.fillAmount = (vidaJugador / vidaMaxima);

        dying = true;
        OnMuerto?.Invoke(this, EventArgs.Empty);        
        animator.SetBool("Dead", true);
        StartCoroutine(PerderControl(4));
        Destroy(gameObject,1.5f);
        Instantiate(tumba, transform.position, Quaternion.identity);
    }

    public void TomarDamage(float daño)
    {
        //audioGolpe.Play();
        vidaJugador -= daño;
        animator.SetTrigger("Dañado");
        StartCoroutine(DesactivarColision(0.5f));

    }
    public void TomarVida(float vida) //cambiar a int si usamos bloques de vida
    {
        vidaJugador += vida;
        barraDeVida.fillAmount = (vidaJugador / vidaMaxima);
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
