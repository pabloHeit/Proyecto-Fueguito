using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogoVendedor : MonoBehaviour
{
    [SerializeField] private Transform textoPanelPos;
    [SerializeField] private GameObject textoPanel;
    [SerializeField] private TMP_Text textoText;
    [SerializeField] private string dialogueLine;
    private bool dialogoActivo=false;

    private void MensajePantalla(){
        dialogoActivo = true;
        textoText.text = dialogueLine;
        textoPanel.SetActive(true);
    }
    private void ApagarMensaje(){
        textoPanel.SetActive(false);
        dialogoActivo = false;
    }  

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player") && !dialogoActivo){         
            MensajePantalla();
        }
    }
    private void OnTriggerExit2D(Collider2D other){
        if (other.CompareTag("Player")){
            ApagarMensaje();
        }
    }
}