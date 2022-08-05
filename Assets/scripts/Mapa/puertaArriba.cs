using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaArriba : MonoBehaviour
{
    LevelGeneration direc;
    public GameObject[] arriba;
    // Start is called before the first frame update
    void Start()
    {
        direc=FindObjectOfType<LevelGeneration>();
        
        if(direc.dire==5 || direc.dire==6)
        {
            GameObject instance = (GameObject)Instantiate(arriba[0], transform.position, Quaternion.identity);
            instance.transform.parent=transform;

        }
         else
        {
            GameObject instance = (GameObject)Instantiate(arriba[1], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
