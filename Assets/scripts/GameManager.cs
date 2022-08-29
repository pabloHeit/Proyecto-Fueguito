using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager Instance;

	public GameState State;
	public static event Action<GameState> OnGameStateChanged;

	void Awake(){
		Instance = this;		
	}

	void Start()
	{
		switch (SceneManager.GetActiveScene().name)
		{
			case "MenuPrincipal":
				UpdateGameState(GameState.MenuPrincipal);
			break;

			case "Cargando":
				UpdateGameState(GameState.Cargando);
			break;
			
			default:
				UpdateGameState(GameState.EnJuego);
			break;
		}
	}

	public void UpdateGameState(GameState newState){
		State = newState;

		switch (newState){
			case GameState.MenuPrincipal:
			break;
			case GameState.Cargando:
				HandleCharging();
			break;
			case GameState.EnJuego:
			break;
			case GameState.Pausado:
				HandlePauseMenu();
			break;
			case GameState.Muerte:
			break;
			
			default:
				throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
		}

		OnGameStateChanged?.Invoke(newState);
	}

	private void HandlePauseMenu(){

	}
	private void HandleCharging(){

	}

}

public enum GameState {
	MenuPrincipal,
	Cargando,
	EnJuego,
	Pausado,
	Muerte
}
