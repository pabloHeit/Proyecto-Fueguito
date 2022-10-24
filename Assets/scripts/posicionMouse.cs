using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posicionMouse : MonoBehaviour
{
    public Vector3 mousePosition;
    void Update()
    {
        if (GameManager.EnableInput){
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            transform.position = mousePosition;            
        }
    }
}
