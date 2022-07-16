using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cofreInteractuable : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private Transform textoPanelPos;
    [SerializeField] private GameObject textoPanel;
    [SerializeField] private TMP_Text textoText;
    [SerializeField] private string dialogueLine;
    private bool comenzoElDialogo=false; 
    private bool cofreAbiertoBool=false;
    private bool EnRango=false;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update() 
    {
        if(EnRango && Input.GetKeyDown(KeyCode.E))
        {          
            animator.SetBool("CofreAbierto", true);
            ApagarMensaje();
            cofreAbiertoBool=true;
        }
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {         
            if (!comenzoElDialogo && cofreAbiertoBool==false)
            {
                MensajePantalla();
            }
            animator.SetBool("CofreMedioAbierto", true);
            EnRango = true;    
        }            
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ApagarMensaje();
            animator.SetBool("CofreMedioAbierto", false);
            EnRango = false;
        }
    }
     private void MensajePantalla()
    {
        comenzoElDialogo = true;
        textoText.text = dialogueLine;
        textoPanel.SetActive(true);
    }
    private void ApagarMensaje()
    {
        textoPanel.SetActive(false);
        comenzoElDialogo = false;
    }  
}
