using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pausa : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;
    public Button continueButton, opcionesButton, exitButton;
    private bool enPausa = false;

    void Start()
    {
        Button continueBtn = continueButton.GetComponent<Button>();
        Button opcionesBtn = opcionesButton.GetComponent<Button>();
        Button exitBtn = exitButton.GetComponent<Button>();

        continueBtn.onClick.AddListener(AlternarPausa);
        //opcionesBtn.onClick.AddListener(AlternarOpciones);
        exitBtn.onClick.AddListener(Application.Quit);
        
        PauseMenu.SetActive(enPausa);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) AlternarPausa();
        
    }

    public void AlternarPausa()
    {
        enPausa = !enPausa;
        if (enPausa) Time.timeScale = 0;
        else Time.timeScale = 1;
        PauseMenu.SetActive(enPausa);
    }
}
