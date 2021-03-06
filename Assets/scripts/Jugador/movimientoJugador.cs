using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoJugador : MonoBehaviour
{
    private Animator animator;
    private int ladoMirar;

    [Header("Movimiento")]
    public bool sePuedeMover=true;
    public float velocidadMovimiento;
    public Vector2 direccion; 
    private Rigidbody2D rb2D;
    private float movimientoX;
    private float movimientoY;
    private Transform _t ;

    [Header("Rodar")]
    [SerializeField] private float velocidadRodar;
    private float rodar;
    public float rodarCooldown;
    private float rodarPermiso;
    public bool mirandoDerecha; //tener en cuenta que siempre comience mirando hacia la derecha
    private Vector2 ultimaDireccion;
    [SerializeField] private float tiempoDeNoMoverse;
    [SerializeField] private float tiempoInvulnerable;

   // [Header("Bufanda")]

    //[SerializeField] private _t bola1;
    //[SerializeField] private _t bola2;

    
    void Start()
    {
        _t = GetComponent<Transform>();
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
       // bola1.position=_t.position; 
       // bola2.position=_t.position; 

        movimientoX=Input.GetAxisRaw("Horizontal");
        movimientoY=Input.GetAxisRaw("Vertical");
        rodar=Input.GetAxisRaw("Jump");
        direccion = new Vector2(movimientoX,movimientoY).normalized;
       
        if (movimientoX!=0 || movimientoY!=0){ //animacion de caminar
            animator.SetBool("IsWalking", true);
            ultimaDireccion=direccion;
        }else {
            animator.SetBool("IsWalking", false);
        }

        //Giración del cuerpo con respecto a donde mira
        ladoMirar = mirandoDerecha ? 0 : 1;
        _t.eulerAngles = new Vector3(0, ladoMirar * 180 , 0);
    }    
    private void FixedUpdate()
    {
        if(sePuedeMover)
        {
            if (movimientoX>=1||movimientoY>=1||movimientoX<=-1||movimientoY<=-1)
            {                
                rb2D.MovePosition(rb2D.position + direccion * velocidadMovimiento * Time.fixedDeltaTime);
            }
            animator.SetBool("Idle",true);
            if ((rodar == 1)&&(Time.time > rodarPermiso))
            {
                animator.SetBool("Idle",false);
                animator.SetTrigger("Rodar");
                rodarPermiso = Time.time + rodarCooldown;
                rb2D.velocity = ultimaDireccion * 20f;
                StartCoroutine(PerderControl(tiempoDeNoMoverse));
                StartCoroutine(DesactivarColision(tiempoInvulnerable));
                StartCoroutine(CoRodar(0.25f));
            }   
        }     
    }
    public void knockbackPlayer(Vector3 knockPosition, int knockback)
    {        
        Vector2 direccion = transform.position - knockPosition;
        Debug.Log($"{direccion.normalized /* * knockback */}");
        rb2D.AddForce(direccion.normalized * knockback);
    }

    public IEnumerator CoRodar(float tiempoRodar)
    {
        yield return new WaitForSeconds(tiempoRodar);
        rb2D.velocity = new Vector2(0,0);
    }
    public IEnumerator DesactivarColision(float TiempoInmunidad)
    {
        Physics2D.IgnoreLayerCollision(3,6,true);
        yield return new WaitForSeconds(TiempoInmunidad);
        Physics2D.IgnoreLayerCollision(3,6,false);
    }

    public IEnumerator PerderControl(float TiempoPerdidaControl)
    {
        sePuedeMover = false;
        yield return new WaitForSeconds(TiempoPerdidaControl);
        sePuedeMover = true;
    }  
}
