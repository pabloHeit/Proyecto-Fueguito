using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemigos : MonoBehaviour
{
  LevelGeneration LevelGeneration;
  
  public GameObject[] objects;

  private bool spawnear = true;

  void Start()
  {
    LevelGeneration = FindObjectOfType<LevelGeneration>();
  }
  private void Update() 
  {
    if (spawnear && LevelGeneration.stopGeneration)
    {
      spawnear = false;
      StartCoroutine(spawnearEnemigos());
    }    
  }

  private IEnumerator spawnearEnemigos()
  {
      yield return new WaitForSeconds(LevelGeneration.tiempoCrearEnemigos);
      int rand = Random.Range(1, 3);
      int rand2=Random.Range(0,objects.Length);
      if(rand==1)
      {
        
        GameObject instance = (GameObject)Instantiate(objects[rand2], transform.position, Quaternion.identity);

        instance.transform.parent = transform;
      }
  }
}
