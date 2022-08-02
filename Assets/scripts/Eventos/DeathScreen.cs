using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;
    public Button exitButton, respawnButton;
    controladorVidas controladorVidas;

    void Start()
    {
        controladorVidas = GameObject.FindGameObjectWithTag("Player").GetComponent<controladorVidas>();
        controladorVidas.OnMuerto += MuertePantalla;

        Button btn = exitButton.GetComponent<Button>();
        btn.onClick.AddListener(Application.Quit);

        Button btn2 = respawnButton.GetComponent<Button>();
        btn2.onClick.AddListener(RespawnCharacter);
    }
    public void RespawnCharacter()
    {
        SceneManager.LoadScene("SampleScene"); //Cambiarla por otra
        Debug.Log("Respawneaste (Patrañas)");
    }

    private void MuertePantalla(object sender, EventArgs e){
        deathScreen.SetActive(true);
    }
            
}
