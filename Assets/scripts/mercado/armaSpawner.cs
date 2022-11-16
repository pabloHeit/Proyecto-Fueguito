using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class armaSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] armas;

    [SerializeField] private float probabilidadGuitarra = 5; // 50% ej
    [SerializeField] private bool guitarraSpawneada = false;
    [SerializeField] private GameObject guitarra;

    List<int> armasSpawneadas = new List<int>();
    [SerializeField] List<Transform> spawners = new List<Transform>();

    void Start()
    {        
        for (int i = 0; i < transform.childCount; i++)
        {
            if (transform.GetChild(i).name == "armaSlot")
            {
                spawners.Add(transform.GetChild(i));                
            }
        }

        foreach (var spawner in spawners)
        {
            spawnArma(spawner);
        }
    }
    
    private void spawnArma(Transform spawner) {
        var armaRandom = Random.Range(0, armas.Length);
        do
        {
            armaRandom = Random.Range(0, armas.Length);
        } while (armasSpawneadas.Contains(armaRandom) && armasSpawneadas.Count < armas.Length);
        
        if(Random.value > 1 - probabilidadGuitarra / 100 && !guitarraSpawneada)
        {
            guitarraSpawneada = true;
            GameObject armaSpawneada = Instantiate(guitarra, spawner.position, Quaternion.identity);
            armaSpawneada.transform.parent = spawner;
        }
        else
        {
            armasSpawneadas.Add(armaRandom);
            GameObject armaSpawneada = Instantiate(armas[armaRandom], spawner.position, Quaternion.identity);
            armaSpawneada.transform.parent = spawner;
        }
    }
}