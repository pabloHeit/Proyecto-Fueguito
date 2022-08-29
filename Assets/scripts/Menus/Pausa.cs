using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Pausa : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu, IndexMenu, OptionsMenu;
    private bool enOpciones = false;
    private bool enPausa;
    private bool enJuego;

    CodigoVolumen CodigoVolumen;
    
    void Awake(){
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }

    private void GameManagerOnOnGameStateChanged(GameState state){
        enPausa = state == GameState.Pausado;
        enJuego = state == GameState.EnJuego;
    }

    void Start()
    {
        PauseMenu.SetActive(false);
        IndexMenu.SetActive(false);
        OptionsMenu.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && (enJuego || enPausa))
            AlternarPausa();
    }

    public void AlternarPausa()
    {
        GameManager.Instance.UpdateGameState( enPausa ? GameState.EnJuego : GameState.Pausado );
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

    public void SalirDelJuego()
    {
        Application.Quit();
    }
}