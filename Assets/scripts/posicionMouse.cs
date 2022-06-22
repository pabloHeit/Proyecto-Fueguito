using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posicionMouse : MonoBehaviour
{
    public Vector3 mousePosition;
    void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
        transform.position = mousePosition;
        
       /* if (Input.GetKeyDown(KeyCode.Escape))
        {            
            Cursor.visible = true;   
        }
        else
        { 
            Cursor.visible = false;
        }*/
        


    }
}
