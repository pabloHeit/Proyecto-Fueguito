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
      if(rand==1)
      {
        GameObject instance = (GameObject)Instantiate(objects[0], transform.position, Quaternion.identity);

        instance.transform.parent = transform;
      }
  }
}
