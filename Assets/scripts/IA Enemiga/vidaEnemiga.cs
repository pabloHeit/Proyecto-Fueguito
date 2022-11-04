using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaEnemiga : MonoBehaviour
{
    AudioSource audioSource;
    Animator anim;
    Rigidbody2D rb;

    public float vida;
    public float vidaInicial;

    [SerializeField] private AudioClip sonidoGolpeado;

    public bool puedeColisionar;

    void Start()
    {
        puedeColisionar = true;
        anim = this.GetComponent<Animator>();
        vidaInicial = vida;
        audioSource = GetComponent<AudioSource>();
    }

    public void Golpe() {
        vida--;
        if (sonidoGolpeado != null) {
            audioSource.PlayOneShot(sonidoGolpeado);
        }
        if(vida <= 0) {
            anim.SetTrigger("Morir");
        }
        anim.SetTrigger("Dañado");
    }

    public void Muerte() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "balas") {
            Golpe();
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "balas") {
            Golpe();
        }        
    }

    public IEnumerator DesactivarColision(float TiempoInmunidad)
    {
        puedeColisionar = false;
        Physics2D.IgnoreLayerCollision(3,6,true);
        yield return new WaitForSeconds(TiempoInmunidad);
        Physics2D.IgnoreLayerCollision(3,6,false);
        puedeColisionar = true;
    }
}