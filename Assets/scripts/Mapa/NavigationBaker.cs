using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationBaker : MonoBehaviour {
    LevelGeneration LevelGeneration;
    public NavMeshSurface2d surface;

    private bool generado = false;

    void Start () 
    {
        surface = GameObject.FindGameObjectWithTag("Navmesh").GetComponent<NavMeshSurface2d>();
        LevelGeneration = FindObjectOfType<LevelGeneration>();
    }

    public void Update()
    {        
        if(LevelGeneration.stopGeneration && !generado)
        {
            generado = true;
            StartCoroutine(starNavMesh());
        }
    }

    public IEnumerator starNavMesh()
    {
        yield return new WaitForSeconds(LevelGeneration.tiempoCrearEnemigos / 2);
        surface.BuildNavMesh();
    }
}