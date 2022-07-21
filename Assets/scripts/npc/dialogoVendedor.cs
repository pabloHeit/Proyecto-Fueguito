using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogoVendedor : MonoBehaviour
{
    [SerializeField] private Transform textoPanelPos;
    [SerializeField] private GameObject textoPanel;
    [SerializeField] private TMP_Text textoText;
    private string dialogueLine;
    private bool dialogoActivo = false;

    [SerializeField] private string[] dialogos;
    private int indexDialogo;
    private float dialogueTime = 0.1f;

    //Audio
    AudioSource voz;
    bool vozPlay = false;
    bool vozToggleChange = true;
    
    private void Start()
    {
        voz = GetComponent<AudioSource>();

        if (dialogos.Length == 0){
            Debug.Log("<color=red>dialogoVendedor ERROR</color>     El mercader no tiene dialogos");
        }        
    }
    void Update()
    {
        if (vozPlay && vozToggleChange){
            voz.Play();
            vozToggleChange = false;
        }
        if (vozPlay == false && vozToggleChange){
            voz.Stop();
            vozToggleChange = false;
        }
    }
/*     void OnGUI()
    {
        //Switch this toggle to activate and deactivate the parent GameObject
        vozPlay = GUI.Toggle(new Rect(10, 10, 100, 30), vozPlay, "Play Music");

        //Detect if there is a change with the toggle
        if (GUI.changed)
        {
            //Change to true to show that there was just a change in the toggle state
            vozToggleChange = true;
        }
    } */

    private void MensajePantalla(){

        dialogoActivo = true;
        textoPanel.SetActive(true);
        dialogueLine = dialogos[ Random.Range(0, dialogos.Length) ];

        StartCoroutine(mostrarDialogo());
    }

    private void ApagarMensaje(){
        textoText.text = "";
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

    IEnumerator mostrarDialogo()
    {
        voz.Play();
        foreach (var letra in dialogueLine){
            
            if (dialogoActivo == false) break;
            textoText.text += letra;
            if (letra.ToString() != " ") /*then*/ yield return new WaitForSeconds(dialogueTime);
        }
        voz.Stop();
        
        
    }
}