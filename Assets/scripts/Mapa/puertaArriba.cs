using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaArriba : MonoBehaviour
{
    LevelGeneration direc;
    public GameObject[] arriba;
    // Start is called before the first frame update
    private void Start()
    {
        direc=FindObjectOfType<LevelGeneration>();
         if(direc.posi==false)
       {
           if(direc.numHabit==10){
            if((direc.direction==7) || (direc.direction==8))
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
            else
            {
        if((direc.direction==7) || (direc.direction==8))
        {
            GameObject instance = (GameObject)Instantiate(arriba[0], transform.position, Quaternion.identity);
            instance.transform.parent=transform;

        }
         else
        {
           if(direc.direcciones[direc.i-1]==5 || direc.direcciones[direc.i-1]==6)
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
        }
       }
       else
       {
         if(direc.direction2==8 || direc.direction2==7)
        {
            GameObject instance = (GameObject)Instantiate(arriba[0], transform.position, Quaternion.identity);
            instance.transform.parent=transform;

        }
         else
        {
            if(direc.direcciones[direc.i-1]==5 || direc.direcciones[direc.i-1]==6)
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
       }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
