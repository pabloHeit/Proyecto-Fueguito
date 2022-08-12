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
      //  Debug.Log("direccion de puerta:" +direc.direction);
        //Debug.Log("la direccion anterior es:"+direc.anterior);
        //Debug.Log("adentro de i"+direc.direcciones[direc.i-1]);
         if(direc.posi==false)
       {
        if((direc.direction==1) || (direc.direction==2))
        {
            GameObject instance = (GameObject)Instantiate(derecha[0], transform.position, Quaternion.identity);
            instance.transform.parent=transform;

        }
         else
        {
            
            if(direc.direcciones[direc.i-1]==3 || direc.direcciones[direc.i-1]==4)
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
        }
       else
       {
         if(direc.direction2==1 || direc.direction2==2)
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
