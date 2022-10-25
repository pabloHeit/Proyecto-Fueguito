using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorMarcoVida : MonoBehaviour
{
    Animator Animator;

    void Awake(){
        StartCoroutine(TemporalErrorFix());
    }

    void OnDestroy(){
        GameManager.OnGameStateChanged -= GameManagerOnOnGameStateChanged;
    }

    private void GameManagerOnOnGameStateChanged(GameState state){
        Animator.SetBool("Muerte", (state == GameState.Muerte));
    }

    private void Start(){
        Animator = GetComponent<Animator>();  
    }

    IEnumerator TemporalErrorFix(){
        yield return new WaitForSeconds(1f);
        GameManager.OnGameStateChanged += GameManagerOnOnGameStateChanged;
    }
}