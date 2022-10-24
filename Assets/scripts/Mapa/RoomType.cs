using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomType : MonoBehaviour
{
    public int type;
    public GameObject[] puertas;
    public void RoomDestruction() 
    {
        Destroy(gameObject);
    }
    public void doorDestruction()
    {
        Destroy(puertas[0]);
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
