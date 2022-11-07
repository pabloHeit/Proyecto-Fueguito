using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemigos : MonoBehaviour
{
  LevelGeneration level;
  
  public GameObject[] objects;

  private bool spawnear = true;

  void Start()
  {
    level = FindObjectOfType<LevelGeneration>();
  }
  private void Update() 
  {
    if (spawnear && level.stopGeneration)
    {
      spawnear = false;
      StartCoroutine(spawnearEnemigos());
    }    
  }

  private IEnumerator spawnearEnemigos()
  {
      yield return new WaitForSeconds(3f);
      int rand = Random.Range(1, 3);
      if(rand==1)
      {
        GameObject instance = (GameObject)Instantiate(objects[0], transform.position, Quaternion.identity);

        instance.transform.parent = transform;
      }
  }
}
