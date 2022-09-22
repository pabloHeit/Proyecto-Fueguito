using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaIzquierda : MonoBehaviour
{
    LevelGeneration direc;
    public GameObject[] izquierda;
    private int habitacion;
    // private bool despues=false;
    // Start is called before the first frame update
    private void Start()
    {
        direc=FindObjectOfType<LevelGeneration>();
      
         if(direc.posi==false)
       {
           if(direc.numHabit==10){
            if((direc.direction==3) || (direc.direction==4))
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
            else if(direc.numHabit==0)
            {
            if(direc.direcciones[direc.i]==1 || direc.direcciones[direc.i]==2)
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
        else if((direc.direction==3) || (direc.direction==4))
        {
            GameObject instance = (GameObject)Instantiate(izquierda[0], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
            // despues=true;
        }
        
            else if(direc.direcciones[direc.i-1]==1 || direc.direcciones[direc.i-1]==2)
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
       else if(direc.i2 == 1 && direc.Cantidad!=0)
       {
        if((direc.direction2==3) || (direc.direction2==4))
        {
             GameObject instance = (GameObject)Instantiate(izquierda[0], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
            Debug.Log("aca");
        }
        else if(direc.direcciones[direc.i-1]==1 || direc.direcciones[direc.i-1]==2)
        {
            GameObject instance = (GameObject)Instantiate(izquierda[0], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
            Debug.Log("aca");
        }
        else
        {
            GameObject instance = (GameObject)Instantiate(izquierda[1], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
        }
       }
       else 
       
       
       if(direc.Cantidad==0) 
        {
            if(direc.direcciones2[direc.i2]==1 || direc.direcciones2[direc.i2]==2)
            {
                 GameObject instance = (GameObject)Instantiate(izquierda[0], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
           Debug.Log("aca");
            }
            else
            {
                GameObject instance = (GameObject)Instantiate(izquierda[1], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
            }
            
        }  
        else
       
       
       
       if((direc.direction2==3 && direc.Cantidad!=0) || (direc.direction2==4 && direc.Cantidad!=0))
        {
            GameObject instance = (GameObject)Instantiate(izquierda[0], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
Debug.Log("aca");
        }

        

         else if(direc.direcciones2[direc.i2-1]==1 || direc.direcciones2[direc.i2-1]==2)
            {
                GameObject instance = (GameObject)Instantiate(izquierda[0], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
            Debug.Log("aca");
            }
            else
            {
  GameObject instance = (GameObject)Instantiate(izquierda[1], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
            }
       habitacion=direc.numHabit-1;
    }
    
}
    
         

  
