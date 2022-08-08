using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CodigoEscenas : MonoBehaviour
{
    private void Awake() 
    {
        var noDestruirEscenas = FindObjectsOfType<CodigoEscenas>();
        if(noDestruirEscenas.Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
}
