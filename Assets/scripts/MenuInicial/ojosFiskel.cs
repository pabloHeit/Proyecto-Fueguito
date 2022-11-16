using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ojosFiskel : MonoBehaviour
{
    RectTransform ojos;
    [SerializeField] RectTransform mouse;

    //South West
    [SerializeField] private Vector2 limiteOjos_SW;
    //North East
    [SerializeField] private Vector2 limiteOjos_NE;
    
    [SerializeField] private Vector2 ojosPosicion_inicial; 
    private Vector2 ojosPosicion;
    private Vector2 ojosProximaPosicion;

    [SerializeField] private float movementMultiplier;

    void Start()
    {
        ojos = GetComponent<RectTransform>();
    }

    void Update()
    {

        ojosProximaPosicion = (mouse.anchoredPosition - ojosPosicion_inicial) * movementMultiplier;
        

        if (ojosProximaPosicion.x <= limiteOjos_NE.x && ojosProximaPosicion.x >= limiteOjos_SW.x)
        {
            ojosPosicion.x = ojosProximaPosicion.x;
        }

        if (ojosProximaPosicion.y <= limiteOjos_NE.y && ojosProximaPosicion.y >= limiteOjos_SW.y)
        {
            ojosPosicion.y = ojosProximaPosicion.y;
        }

        ojos.anchoredPosition = new Vector2(ojosPosicion.x, ojosPosicion.y);
    }
}