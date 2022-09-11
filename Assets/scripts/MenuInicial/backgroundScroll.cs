using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundScroll : MonoBehaviour
{

    Material material;
    Vector2 offset;

    [SerializeField] private float xVelocity, yVelocity;
    
    private void Awake(){
        material = GetComponent<Renderer>().material;        
    }
    
    private void Start(){
        offset = new Vector2(xVelocity, yVelocity);     
    }
    
    void Update(){
        material.mainTextureOffset += offset * Time.deltaTime;        
    }
}
