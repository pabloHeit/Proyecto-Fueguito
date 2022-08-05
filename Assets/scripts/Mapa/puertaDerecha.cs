using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaDerecha : MonoBehaviour
{
    LevelGeneration direc;

    public GameObject[] derecha;
    // Start is called before the first frame update
    private void Start()
    {
        direc=FindObjectOfType<LevelGeneration>();
        Debug.Log("direccion de puerta:" +direc.direction);
        if(direc.dire==3 || direc.dire==4)
        {
            GameObject instance = (GameObject)Instantiate(derecha[0], transform.position, Quaternion.identity);
            instance.transform.parent=transform;

        }
         else
        {
            GameObject instance = (GameObject)Instantiate(derecha[1], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
