using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class armaSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] armas;

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
            spawnArma(spawner.position);            
        }

    }
    
    private void spawnArma(Vector3 position) {
        var armaRandom = Random.Range(0, armas.Length);
        do
        {
            armaRandom = Random.Range(0, armas.Length);
        } while (armasSpawneadas.Contains(armaRandom) && armasSpawneadas.Count < armas.Length);
        
        armasSpawneadas.Add(armaRandom);
        Instantiate(armas[armaRandom], position, Quaternion.identity);
    }
}
