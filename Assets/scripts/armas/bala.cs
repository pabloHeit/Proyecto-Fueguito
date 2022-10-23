using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
  AudioSource audioSource;

  [SerializeField] private float tiempoBala;
  [SerializeField] private GameObject efectoImpacto;
  [SerializeField] private float bulletDisappear;
  [SerializeField] private AudioClip sonidoImpacto;

  private  Quaternion ultimaRotacion;
  private Animator animator;

  private void Start(){
    animator = GetComponent<Animator>();
    audioSource = GetComponent<AudioSource>();
  }

  private void FixedUpdate() {
    Destroy(gameObject, tiempoBala);        
  }     

  private void OnTriggerEnter2D(Collider2D other) {
    if (!other.CompareTag("Enemigo")) {
      audioSource.PlayOneShot(sonidoImpacto);
      ultimaRotacion = Quaternion.Euler(0,0,transform.eulerAngles.z);
      GameObject efecto = Instantiate(efectoImpacto, transform.position, ultimaRotacion);
      Destroy(efecto, bulletDisappear);
    }
    Destroy(gameObject);
  }
}