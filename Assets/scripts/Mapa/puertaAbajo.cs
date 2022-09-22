using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaAbajo : MonoBehaviour
{
    LevelGeneration direc;
    public GameObject[] abajo;
    private int habitacion;
    // private bool despues=false;
    // Start is called before the first frame update
    private void Start()
    {
        direc=FindObjectOfType<LevelGeneration>();
        
       if(direc.posi==false)
       {
            if(direc.numHabit==10){
            if((direc.direction==5) || (direc.direction==6))
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
            else
            {
      if(direc.numHabit==0)
        {
            if(direc.direcciones[direc.i]==7 || direc.direcciones[direc.i]==8)
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
        else
        {
            
            if(direc.direction==5 || direc.direction==6)
            {
                GameObject instance = (GameObject)Instantiate(abajo[0], transform.position, Quaternion.identity);
                instance.transform.parent=transform;
            // despues=true;
            }
            else
            {
                if(direc.direcciones[direc.i-1]==7 || direc.direcciones[direc.i-1]==8)
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
            }
            }
    }
            else
            {

                if(direc.i2 == 1 && direc.Cantidad!=0)
        {
            if((direc.direction2==5) || (direc.direction2==6))
        {
             GameObject instance = (GameObject)Instantiate(abajo[0], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
            Debug.Log("aca");
        }
        else if(direc.direcciones[direc.i-1]==7 || direc.direcciones[direc.i-1]==8)
        {
            GameObject instance = (GameObject)Instantiate(abajo[0], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
            Debug.Log("aca");
        }
        else
        {
            GameObject instance = (GameObject)Instantiate(abajo[1], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
        }
        }
        else
        {
            if(direc.Cantidad==0) 
        {
            if(direc.direcciones2[direc.i2]==7 || direc.direcciones2[direc.i2]==8)
            {
                 GameObject instance = (GameObject)Instantiate(abajo[0], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
           Debug.Log("aca");
            }
            else
            {
                GameObject instance = (GameObject)Instantiate(abajo[1], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
            }
            
        }  
        else{

            if(direc.direction2==5 || direc.direction2==6)
            {
                GameObject instance = (GameObject)Instantiate(abajo[0], transform.position, Quaternion.identity);
                instance.transform.parent=transform;
                Debug.Log("aca");

            }
            else
            {

          

                if(direc.direcciones2[direc.i2-1]==7 || direc.direcciones2[direc.i2-1]==8)
                {
                    GameObject instance = (GameObject)Instantiate(abajo[0], transform.position, Quaternion.identity);
                instance.transform.parent=transform;
                Debug.Log("aca");
                }
                else
                {
                GameObject instance = (GameObject)Instantiate(abajo[1], transform.position, Quaternion.identity);
                instance.transform.parent=transform;
                }
            }  
        
            }
            habitacion=direc.numHabit-1;
            }
    }
    }
}
    
  
