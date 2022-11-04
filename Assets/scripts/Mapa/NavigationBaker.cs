using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationBaker : MonoBehaviour {
    LevelGeneration level;
    private NavMeshSurface2d surface;

    private bool generado = false;

    void Start () 
    {
        surface = GameObject.FindGameObjectWithTag("Navmesh").GetComponent<NavMeshSurface2d>();
        level=FindObjectOfType<LevelGeneration>();
    }

     public void Update()
     {
        
        if(level.stopGeneration && !generado)
        {
            generado = true;
            starNavMesh();
        }
    }

    public void starNavMesh()
    {
        surface.BuildNavMesh();
    }
}