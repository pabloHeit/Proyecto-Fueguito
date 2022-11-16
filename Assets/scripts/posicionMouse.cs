using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class posicionMouse : MonoBehaviour
{
    RectTransform RectTransform;
    public Vector3 mousePosition;
    [SerializeField] private float multiplier;
    [SerializeField] private bool menuPrincipal = false;
    
    void Start()
    {
        RectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (GameManager.EnableInput){
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = Camera.main.transform.position.z + Camera.main.nearClipPlane;
            if (menuPrincipal)
                RectTransform.anchoredPosition = new Vector2(mousePosition.x * multiplier, mousePosition.y * multiplier);
            else
                transform.position = mousePosition;            
        }
    }
}