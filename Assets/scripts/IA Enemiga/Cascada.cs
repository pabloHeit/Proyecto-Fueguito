using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cascada : MonoBehaviour
{
    private bool ataque;
    private controladorVidas controladorVidas;
    [SerializeField] private float daño;


    void Start()
    {
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
    }
    void OnTriggerEnter2D(Collider2D other) 
        {
          Debug.Log(other);
          if(other.CompareTag("cofre"))
            Debug.Log("buleriabuleria");
           if(other.CompareTag("Player"))
            {            
              Debug.Log("Holaa");
              controladorVidas.TomarDamage(daño);
            }
            Destroy(this.gameObject);
        }  
 
 
    private void OnCollisionEnter2D(Collision2D other) {
      Destroy(this.gameObject);
    }

}
