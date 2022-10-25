using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemigos : MonoBehaviour
{
    
    public GameObject[] objects;
    void Start()
    {
         int rand = Random.Range(1, 3);
      if(rand==1)
      {
        GameObject instance = (GameObject)Instantiate(objects[0], transform.position, Quaternion.identity);
      instance.transform.parent=transform;
      }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
