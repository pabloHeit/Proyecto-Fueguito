using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cofreInteractuable : MonoBehaviour
{
    Animator animator;
    AudioSource audioSource;

    [SerializeField] private Transform textoPanelPos;
    [SerializeField] private GameObject textoPanel;
    [SerializeField] private TMP_Text textoText;

    [SerializeField] private string dialogueLine;
    private bool comenzoElDialogo = false; 
    private bool cofreAbiertoBool = false;
    private bool EnRango = false;

    [SerializeField] private AudioClip sonidoCofre;


    [Header("Loot")]
    [SerializeField] private GameObject[] loot;
    private int lootGenerado;

    private Vector3 abajo;

    private void Start()
    {
        textoPanel = GameObject.Find("Canvas dialogos");
        textoPanel = textoPanel.transform.GetChild(0).gameObject;
        textoPanelPos = textoPanel.GetComponent<RectTransform>();
        textoText = textoPanelPos.GetChild(0).GetComponent<TMP_Text>();

        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        GenerarContenido();
    }

    private void Update() 
    {
        if(EnRango && Input.GetKeyDown(KeyCode.E) && !cofreAbiertoBool && GameManager.EnableInput)
        {
            audioSource.PlayOneShot(sonidoCofre);
            animator.SetBool("CofreAbierto", true);
            ApagarMensaje();
            cofreAbiertoBool = true;
            SpawnLoot();
        }
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {         
            if (!comenzoElDialogo && cofreAbiertoBool == false)
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

    private void GenerarContenido()
    {
        lootGenerado = Random.Range(0, loot.Length);
    }

    private void SpawnLoot()
    {
        GameObject lootItem = Instantiate( loot[lootGenerado], transform.position, Quaternion.identity);
        StartCoroutine(moverItem(lootItem));            

    }
    private IEnumerator moverItem(GameObject lootItem)
    {
        float resta = lootItem.transform.position.y;
        abajo = new Vector3(transform.position.x, transform.position.y - 1, transform.position.z);
        while (lootItem.transform.position.y >= abajo.y){
            resta -= 0.1f;
            lootItem.transform.position = new Vector3(lootItem.transform.position.x, resta, lootItem.transform.position.z);
            yield return new WaitForSeconds(0.025f);
        }
        
        
    }
}
