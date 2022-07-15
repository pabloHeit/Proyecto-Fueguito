using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
  [SerializeField] private float tiempoBala;
  [SerializeField] private GameObject efectoImpacto;
  [SerializeField] private float bulletDisappear;
  private  Quaternion ultimaRotacion;
  private Animator animator;

  //Aca van todas las layer que debe ignorar
  [SerializeField] private int[] layerIgnoradas;

  private void Start(){
  	animator = GetComponent<Animator>();

    foreach (int n in layerIgnoradas){
      Physics2D.IgnoreLayerCollision(n ,7,true);
    }
  }

  private void FixedUpdate(){
    Destroy(gameObject, tiempoBala);        
  }     

  private void OnTriggerEnter2D(Collider2D other){
    if( !( other.CompareTag("Player") ) ){
      ultimaRotacion = Quaternion.Euler(0,0,transform.eulerAngles.z);
      GameObject efecto = Instantiate(efectoImpacto, transform.position, ultimaRotacion); /* Solucionar posteriormente la rotacion del impacto (Vease bloc de notas idea rotación)*/
      Destroy(efecto, bulletDisappear);
      Destroy(gameObject);      
    }
  }
}