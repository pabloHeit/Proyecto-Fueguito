using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{

  [SerializeField] private float tiempoBala;
  [SerializeField] private float daño;
  [SerializeField] private GameObject efectoImpacto;
  [SerializeField] private float bulletDisappear;

  private  Quaternion ultimaRotacion;
  private Animator animator;

  private void Start(){
    animator = GetComponent<Animator>();
  }

  private void FixedUpdate() {
    Destroy(gameObject, tiempoBala);        
  }     

  private void OnCollisionEnter2D(Collision2D other) {    
      if (other.gameObject.CompareTag("Enemigo")) {
          other.gameObject.GetComponent<vidaEnemiga>().Golpe(daño);  
      }
      else
      {
          ultimaRotacion = Quaternion.Euler(0, 0, transform.eulerAngles.z);
          GameObject efecto = Instantiate(efectoImpacto, transform.position, ultimaRotacion);
          Destroy(efecto, bulletDisappear);
      }
      Destroy(gameObject);
    }
}