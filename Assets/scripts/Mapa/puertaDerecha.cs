using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puertaDerecha : MonoBehaviour
{
    LevelGeneration direc;
    public GameObject[] derecha;
    private int habitacion;

    private void Start()
    {
       
        direc=FindObjectOfType<LevelGeneration>();
        
        // Debug.Log("direccion de puerta:" +direc.direction);
        // Debug.Log("el numhabit es: "+direc.numHabit);
        // Debug.Log("la anterior es: "+direc.direcciones[direc.i-1]);
        // Debug.Log("i es "+direc.i);
        
         if(direc.posi==false)
       {
           if(direc.numHabit==10){
            if((direc.direction==1) || (direc.direction==2))
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
            else
            {
                  if(direc.numHabit==0)
        {
            if(direc.direcciones[direc.i]==3 || direc.direcciones[direc.i]==4)
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
        else
        {
        if((direc.direction==1) || (direc.direction==2))
        {
            GameObject instance = (GameObject)Instantiate(derecha[0], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
            // despues=true;
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
            }
    }
       else
       {
        
        if(direc.i2 == 0)
        {
            if((direc.direction==1) || (direc.direction==2))
        {
             GameObject instance = (GameObject)Instantiate(derecha[0], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
        }
        else if(direc.direcciones[direc.i-1]==3 || direc.direcciones[direc.i-1]==4)
        {
            GameObject instance = (GameObject)Instantiate(derecha[0], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
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

            if(direc.Cantidad==0 && (direc.direcciones2[direc.i2]==3 || direc.direcciones2[direc.i2]==4))
        {
             GameObject instance = (GameObject)Instantiate(derecha[0], transform.position, Quaternion.identity);
            instance.transform.parent=transform;
        }
        else
        {

          if(direc.direcciones2[direc.i2-1]==3 || direc.direcciones2[direc.i2-1]==4)
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
       
        habitacion=direc.numHabit-1;
    }
    }
       }
    }

    // Update is called once per frame
    // void Update()dd
    // {
    //     if(habitacion==direc.numHabit && despues==true){
    //         if(direc.ocupado==true){
    //             Debug.Log("despues esta ocupado");
                
    //         }
    //     }
    // }
}
