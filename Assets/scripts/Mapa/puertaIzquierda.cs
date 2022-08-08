using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaIzquierda : MonoBehaviour
{
    LevelGeneration direc;
    public GameObject[] izquierda;
    // Start is called before the first frame update
    private void Start()
    {
        direc=FindObjectOfType<LevelGeneration>();
        
        if((direc.direction==3) || (direc.direction==4))
        {
            GameObject instance = (GameObject)Instantiate(izquierda[0], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
             Debug.Log("direccion de puerta:" +direc.direction);
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
