using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerminarJuego : MonoBehaviour
{
    private bool EnRango = false;

    private void Update() 
    {
        if(EnRango && Input.GetKeyDown(KeyCode.E))
        {
            GameOver();
        }
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {         
            EnRango = true;    
        }            
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            EnRango = false;
        }
    }
    
    public void GameOver()
    {
        levelLoader.LoadLevel("Creditos");
    }
}
