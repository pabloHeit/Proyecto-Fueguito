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
    private bool enPinchos=false;
    void Start()
    {
        animator = GetComponent<Animator>();
        movimientoJugador= GetComponent<movimientoJugador>();
        audioGolpe = GetComponent<AudioSource>();
        barraDeVida.fillAmount = (vidaJugador / vidaMaxima);

    }
    void Update()
    {
        if(enPinchos)
        {
            TomarDaño(0.1f);
        }
        if (vidaJugador<=0)
        {
            Destroy(ojos);
            OnMuerto?.Invoke(this, EventArgs.Empty);        
            animator.SetBool("Dead", true);
            StartCoroutine(PerderControl(2));
            Destroy(gameObject,1.5f);
            //Destroy(bufanda,1.5f);          
        } 
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        /*if (other.CompareTag("dañoEnemigo"))
        {
            TomarDaño(10);
            StartCoroutine(DesactivarColision(tiempoInmunidad));
        }
        else*/ if(other.CompareTag("pinchos"))
        {
            enPinchos=true;
        }
            
    }
    private void OnTriggerExit2D(Collider2D other)
    {   
        if (other.CompareTag("pinchos"))
        {
            enPinchos=false;
        }     
    }
    public void TomarDaño(float daño)
    {
        //audioGolpe.Play();
        vidaJugador-=daño;
        animator.SetBool("Idle",false);
        animator.SetTrigger("Dañado");
        barraDeVida.fillAmount = (vidaJugador / vidaMaxima);

    }
    public IEnumerator DesactivarColision(float TiempoInmunidad)
    {
        Physics2D.IgnoreLayerCollision(6,7,true);
        yield return new WaitForSeconds(TiempoInmunidad);
        Physics2D.IgnoreLayerCollision(6,7,false);
    }
    public IEnumerator PerderControl(float TiempoPerdidaControl)
    {
        movimientoJugador.sePuedeMover = false;
        yield return new WaitForSeconds(TiempoPerdidaControl);
        movimientoJugador.sePuedeMover = true;
    }

}
