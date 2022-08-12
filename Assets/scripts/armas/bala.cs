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
  private void Start()
  {
  	animator= GetComponent<Animator>();
  }
  private void FixedUpdate() 
  {
    Destroy(gameObject, tiempoBala);        
  }     
  private void OnTriggerEnter2D(Collider2D other)
  {
        if(!(other.CompareTag("Player")))
        {
          IA2 enemigo = other.GetComponent<IA2>(); 
          N1_IA enemigo2 = other.GetComponent<N1_IA>();
          if(enemigo != null)
           {
            enemigo.Golpe();
           } 
          if (enemigo2 != null)
          {
            enemigo2.Golpe();
          } 

            ultimaRotacion = Quaternion.Euler(0,0,transform.eulerAngles.z);
            GameObject efecto = Instantiate(efectoImpacto, transform.position, ultimaRotacion); /* Solucionar posteriormente la rotacion del impacto (Vease bloc de notas idea rotación)*/
            Destroy(efecto, bulletDisappear);
            Destroy(gameObject);
        }
    }


    

}