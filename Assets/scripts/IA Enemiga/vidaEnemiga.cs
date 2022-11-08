using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaEnemiga : MonoBehaviour
{
    Animator anim;
    Rigidbody2D rb;
    public bool muerto=false;
    public float vida;
    public float vidaInicial;

    public bool puedeColisionar;

    void Start()
    {
        puedeColisionar = true;
        anim = this.GetComponent<Animator>();
        vidaInicial = vida;
    }

    public void Golpe() {
        vida--;
        if(vida <= 0) {
            anim.SetTrigger("Morir");
            muerto=true;
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

    public IEnumerator DesactivarColision(float TiempoInmunidad)
    {
        puedeColisionar = false;
        Physics2D.IgnoreLayerCollision(3,6,true);
        yield return new WaitForSeconds(TiempoInmunidad);
        Physics2D.IgnoreLayerCollision(3,6,false);
        puedeColisionar = true;
    }
}