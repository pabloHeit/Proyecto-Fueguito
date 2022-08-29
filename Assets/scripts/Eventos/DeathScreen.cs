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

    void Awake(){
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }

    void OnDestroy(){
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }

    private void GameManagerOnOnGameStateChanged(GameState state){
        deathScreen.SetActive( state == GameState.Muerte );
    }

    void Start()
    {
        Button btn = exitButton.GetComponent<Button>();
        btn.onClick.AddListener(Application.Quit);

        Button btn2 = respawnButton.GetComponent<Button>();
        btn2.onClick.AddListener(RespawnCharacter);
    }
    
    public void RespawnCharacter()
    {
        SceneManager.LoadScene("SampleScene"); //Cambiarla por otra
    }
}
