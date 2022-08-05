using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaAbajo : MonoBehaviour
{
    LevelGeneration direc;

    public GameObject[] abajo;
    // Start is called before the first frame update
    void Start()
    {
        direc=FindObjectOfType<LevelGeneration>();
       
        if(direc.dire==7 || direc.dire==8)
        {
            GameObject instance = (GameObject)Instantiate(abajo[0], transform.position, Quaternion.identity);
            instance.transform.parent=transform;

        }
         else
        {
            GameObject instance = (GameObject)Instantiate(abajo[1], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
