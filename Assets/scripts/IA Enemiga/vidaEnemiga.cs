using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class vidaEnemiga : MonoBehaviour
{
    AudioSource audioSource;
    Animator anim;
    Rigidbody2D rb;
    public bool muerto = false;
    public float vida;
    public float vidaInicial;

    [SerializeField] private AudioClip sonidoGolpeado;

    public bool puedeColisionar;

    private Transform habitacion;

    [SerializeField] private GameObject loot;

    void Start()
    {
        if (this.transform.parent.parent != null)
            habitacion = this.transform.parent.parent;
        
        puedeColisionar = true;
        anim = this.GetComponent<Animator>();
        vidaInicial = vida;
        audioSource = GetComponent<AudioSource>();
    }

    public void Golpe(float daño) {
        vida -= daño;
        if (sonidoGolpeado != null) {
            audioSource.PlayOneShot(sonidoGolpeado);
        }
        if(vida <= 0) {
            anim.SetTrigger("Morir");
            muerto=true;
        }
        anim.SetTrigger("Dañado");
    }

    public void Muerte() {
        if (loot != null)
        {
            int randomNumber = Random.Range(0, 2);
            Debug.Log(randomNumber);
            if (randomNumber == 1) {
                Instantiate(loot, transform.position, Quaternion.identity);            
            }            
        }

        Destroy(gameObject);
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