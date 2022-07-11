using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorCamara : MonoBehaviour
{
    private float zOffset = -1;

    [SerializeField] Transform player;

    [Header("El punto donde se quiera centrar la camara")]
    [SerializeField] public Transform puntoFijo;

    [Header("Tamaño de la camara (5.5 es la default)")]
    [SerializeField] public float cameraSize;

    private Transform _t;    
    public bool camaraFija = true;

    private void Awake(){
        _t = GetComponent<Transform>();
        Camera.main.orthographicSize = cameraSize ;

    }

    void Update()
    {
        if (camaraFija){
            CamaraFija();
        }else{
            CamaraMovil();
        }        
    }
    
    public void CamaraFija(){
        if (puntoFijo != null){
            _t.position = new Vector3(puntoFijo.position.x, puntoFijo.position.y, zOffset);
        }
    }

    public void CamaraMovil(){
        if (player != null){
            _t.position = new Vector3(player.position.x, player.position.y, zOffset);
        }        
    }
}
