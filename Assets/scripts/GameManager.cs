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

	public static bool EnableInput;


	void Awake(){
		if (Instance != null){
			Destroy(this);
		}
		else{
			Instance = this;			
		}
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
				HandlePrincipalMenu();
			break;
			case GameState.Cargando:
				HandleCharging();
			break;
			case GameState.EnJuego:
				HandleGaming();
			break;
			case GameState.Pausado:
				HandlePauseMenu();
			break;
			case GameState.Muerte:
				HandleDeath();
			break;
			
			default:
				throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
		}

		OnGameStateChanged?.Invoke(newState);
	}

	private void HandlePrincipalMenu(){
		Cursor.visible = true;
	}

	private void HandleCharging(){
		EnableInput = false;
		Cursor.visible = false;
	}

	private void HandleGaming(){
		EnableInput = true;
		Cursor.visible = true; 
	}

	private void HandlePauseMenu(){
		Cursor.visible = true;
		EnableInput = false;
	}

	private void HandleDeath(){
		Cursor.visible = true;
		EnableInput = false;
	}
}

public enum GameState {
	MenuPrincipal,
	Cargando,
	EnJuego,
	Pausado,
	Muerte
}