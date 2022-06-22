using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class controladorEspada : MonoBehaviour
{
    private Animator Animator;
    private Transform _t;
    [SerializeField] private Transform espada;
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;
    private int i;
    private Vector3 mousePosition;
    SpriteRenderer sprite;
    private movimientoJugador movimientoJugador;    

    [Header ("HUD")]
    [SerializeField] private GameObject marcadorBalas;
    private TextMeshProUGUI textMesh;

    void Start()
    {
        _t = GetComponent<Transform>();
        Animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        movimientoJugador = GameObject.FindGameObjectWithTag("Player").GetComponent<movimientoJugador>();  	
    }

    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        Vector3 lookAtDirection = mousePosition - espada.position;
        espada.right = lookAtDirection;

        TextMeshProUGUI textMesh = marcadorBalas.GetComponent<TextMeshProUGUI>();
        textMesh.text = ""; // Borrar cantidad de balas

        if(Input.GetButtonDown("Fire1")) //Boton de ataque
        {
            Golpe();
        }

	    sprite.flipY = !movimientoJugador.mirandoDerecha;
    }    
    
    private void Golpe()
    {
        Animator.SetTrigger("ataque");
        
        Collider2D[] objetos = Physics2D.OverlapCircleAll(controladorGolpe.position, radioGolpe);
        foreach (Collider2D colisionador in objetos)
        {
            if (colisionador.CompareTag("Enemigo"))
            {
                Debug.Log("Le pegaste al enemigo");
                //colisionador.transform.GetComponent<Enemigo>().TomarDaño(dañoGolpe);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(controladorGolpe.position, radioGolpe);
    }
}
