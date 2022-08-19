using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaAgua : MonoBehaviour
{
   private Rigidbody2D Rigidbody2D;
   Animator anim;
   private controladorVidas controladorVidas;
   [SerializeField] private float daño;
   private Transform player;
   [SerializeField] private Transform enemigo;
   [SerializeField] private Transform objetivo;
   [SerializeField] private float TiempoBala;

    void Start()
    {
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }    

   void FixedUpdate(){
      player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    
   }

  public void OnTriggerEnter2D(Collider2D other) {
      
        if((other.CompareTag("Player")))
        {
            controladorVidas.TomarDaño(daño);
        }
     /* GameObject efecto1 = Instantiate(efectoImpacto, balaene.position, balaene.rotation); 
          Destroy(efecto1, TiempoBala);*/
    }
    

}
 
    
    


