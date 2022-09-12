using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaArriba : MonoBehaviour
{
    LevelGeneration direc;
    public GameObject[] arriba;
    private int habitacion;
    // private bool despues=false;
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
                      if(direc.numHabit==0)
        {
            if(direc.direcciones[direc.i]==5 || direc.direcciones[direc.i]==6)
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
            // despues=true;
        }
            else{ 
                if(direc.direcciones[direc.i-1]==5 || direc.direcciones[direc.i-1]==6)
            {
                Debug.Log("aca");
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
       habitacion=direc.numHabit-1;
    }
    }

   

