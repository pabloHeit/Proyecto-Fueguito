using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class dialogoVendedor : MonoBehaviour
{
    [SerializeField] private Transform textoPanelPos;
    [SerializeField] private GameObject textoPanel;
    [SerializeField] private TMP_Text textoText;

    [SerializeField] private string[] dialogos;

    private bool dialogoActivo = false;
    private string dialogueLine;    
    private int indexDialogo;
    private float dialogueTime = 0.05f;

    private bool pausado, enPausa;
    
    //Audio
    AudioSource voz;
    bool vozPlay = false;
    bool vozToggleChange = true;
    
    private void Start()
    {
        textoPanel = GameObject.Find("Canvas dialogos");
        textoPanel = textoPanel.transform.GetChild(1).gameObject;
        textoPanelPos = textoPanel.GetComponent<RectTransform>();
        textoText = textoPanelPos.GetChild(0).GetComponent<TMP_Text>();

        voz = GetComponent<AudioSource>();
        if (dialogos.Length == 0){
            Debug.Log("<color=red>dialogoVendedor ERROR</color>     El mercader no tiene dialogos");
        }
    }

    void Awake(){
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }

    void OnDestroy(){
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }

    private void GameManagerOnOnGameStateChanged(GameState state){
        enPausa = state == GameState.Pausado;
    }

    void Update()
    {
        if (pausado)        
            voz.UnPause();        
        
        if (enPausa){
            voz.Pause();
            pausado = true;
        }
        else
        {
            if (vozPlay && vozToggleChange){
                voz.Play();
                vozToggleChange = false;
            }
            if (!vozPlay && vozToggleChange){
                voz.Stop();
                vozToggleChange = false;
            }
        }
        
    }

    private void MensajePantalla(){

        textoPanel.SetActive(true);

        dialogoActivo = true;

        dialogueLine = dialogos[ Random.Range(0, dialogos.Length) ];

        StartCoroutine(mostrarDialogo());
    }

    private void ApagarMensaje(){

        textoPanel.SetActive(false);
        dialogoActivo = false;
        textoText.text = "";
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
            
            if (!dialogoActivo) 
                break;

            textoText.text += letra;

            if (letra.ToString() != " ") 
                yield return new WaitForSeconds(dialogueTime);
        }

        voz.Stop();       
    }
}