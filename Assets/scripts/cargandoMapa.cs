using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cargandoMapa : MonoBehaviour
{
    LevelGeneration LevelGeneration;

    void Start()
    {
        GameManager.Instance.UpdateGameState(GameState.Cargando);
        LevelGeneration = FindObjectOfType<LevelGeneration>();
    }

    void Update()
    {
        if (GameManager.EnableInput)
        {
            GameManager.Instance.UpdateGameState(GameState.Cargando);
        }

        if (LevelGeneration.stopGeneration)
        {
            StartCoroutine(terminarCarga());
        }
    }

    private IEnumerator terminarCarga()
    {
        yield return new WaitForSeconds(LevelGeneration.tiempoCrearEnemigos);
        GameManager.Instance.UpdateGameState(GameState.EnJuego);
        Destroy(gameObject);        
    }
}