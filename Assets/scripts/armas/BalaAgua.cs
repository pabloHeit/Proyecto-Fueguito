using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaAgua : MonoBehaviour
{
   private Rigidbody2D Rigidbody2D;
   private controladorVidas controladorVidas;
   [SerializeField] private float daño;

    void Start()
    {
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

  public void OnTriggerEnter2D(Collider2D other) {
      
        if((other.CompareTag("Player")))
        {
            controladorVidas.TomarDaño(daño);
            Destroy(gameObject);
        }

    }
      
}
 
    
    


