using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaOpciones : MonoBehaviour
{
    public ControladorOpciones panelOpciones;
    public bool juegoInicio = false;
    [SerializeField] private GameObject menuOpciones, menuPrincipal;

    void Start(){
        panelOpciones = GameObject.FindGameObjectWithTag("opciones").GetComponent<ControladorOpciones>();
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.Escape) && juegoInicio)
        {
            MostrarOpciones();
        }
    }

    public void MostrarOpciones()
    {
        panelOpciones.pantallaOpciones.SetActive(true);
    }

    public void BotonVolver()
    {
        if (menuPrincipal != null)
        {
            menuPrincipal.SetActive(true);            
        }
        menuOpciones.SetActive(false);
    }


}