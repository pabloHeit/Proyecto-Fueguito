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
		Instance = this;		
	}

	void Start()
	{
		UpdateGameState(GameState.MenuPrincipal);
	}

	public void UpdateGameState(GameState newState){
		State = newState;
		Cursor.visible = true;

		switch (newState){
			case GameState.MenuPrincipal:
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
			break;
			
			default:
				throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
		}

		OnGameStateChanged?.Invoke(newState);
	}

	private void HandlePauseMenu(){
		EnableInput = false;
	}
	private void HandleCharging(){
		EnableInput = false;
	}
	private void HandleGaming(){
		EnableInput = true;
		Cursor.visible = false;
	}
}

public enum GameState {
	MenuPrincipal,
	Cargando,
	EnJuego,
	Pausado,
	Muerte
}
