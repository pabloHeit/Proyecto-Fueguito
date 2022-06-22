using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armaSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] armas;
    private int armaSpawneada;
    void Start()
    {
        spawnArma();
    }
    private void spawnArma(){
        armaSpawneada = Random.Range(0, armas.Length);
        Instantiate(armas[armaSpawneada], transform.position, Quaternion.identity);
    }
}
