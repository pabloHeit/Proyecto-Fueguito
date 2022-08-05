using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaIzquierda : MonoBehaviour
{
    LevelGeneration direc;

    public GameObject[] izquierda;
    // Start is called before the first frame update
    void Start()
    {
        direc=FindObjectOfType<LevelGeneration>();
        
        if(direc.dire==1 || direc.dire==2)
        {
            GameObject instance = (GameObject)Instantiate(izquierda[0], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
            
        }
        else
        {
            GameObject instance = (GameObject)Instantiate(izquierda[1], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
