using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Pausa : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu, IndexMenu, OptionsMenu;
    public Button continueButton, opcionesButton, exitButton, volverButton;
    public bool enJuego = true;
    public bool enPausa = false;
    private bool enOpciones = false;
    CodigoVolumen CodigoVolumen;

    void Start()
    {
        Button continueBtn = continueButton.GetComponent<Button>();
        Button opcionesBtn = opcionesButton.GetComponent<Button>();
        Button exitBtn = exitButton.GetComponent<Button>();
        Button volverBtn = volverButton.GetComponent<Button>();

        continueBtn.onClick.AddListener(AlternarPausa);
        opcionesBtn.onClick.AddListener(AlternarOpciones);
        exitBtn.onClick.AddListener(Application.Quit);
        volverBtn.onClick.AddListener(AlternarOpciones);

        PauseMenu.SetActive(false);
        IndexMenu.SetActive(false);
        OptionsMenu.SetActive(false);
    }

    void Update()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name != "MenuPrincipal" && scene.name != "Cargando")
            enJuego = true;                        
        else enJuego = false;

        if(Input.GetKeyDown(KeyCode.Escape) && enJuego) AlternarPausa();
    }

    public void AlternarPausa()
    {
        enPausa = !enPausa;
        if (enPausa) Time.timeScale = 0;
        else{
            Time.timeScale = 1;
            enOpciones = false;
            OptionsMenu.SetActive(enOpciones);
        }
        PauseMenu.SetActive(enPausa);
        IndexMenu.SetActive(enPausa);
    }

    public void AlternarOpciones()
    {
        enOpciones = !enOpciones;
        IndexMenu.SetActive(!enOpciones);
        OptionsMenu.SetActive(enOpciones);
    }    
}