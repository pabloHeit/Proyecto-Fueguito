using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cierredepuerta : MonoBehaviour
{
    encima encima;
    // Start is called before the first frame update
    void Start()
    {
        encima=FindObjectOfType<encima>();
    }

    // Update is called once per frame
    void Update()
    {
        if(encima.encierro==true)
        {
            BoxCollider2D sc = gameObject.AddComponent(typeof(BoxCollider2D)) as BoxCollider2D;
        }
    }
}
