using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimientoJugador : MonoBehaviour
{
    private Animator animator;

    [Header("Movimiento")]
    public bool sePuedeMover=true;
    public float velocidadMovimiento;
    public Vector2 direccion; 
    private Rigidbody2D rb2D;
    private float movimientoX;
    private float movimientoY;

    [Header("Rodar")]
    public float velocidadRodar;
    private float rodar;
    public float rodarCooldown;
    private float rodarPermiso;
    private bool mirandoDerecha=true;
    private Vector2 ultimaDireccion;
    [SerializeField] private float tiempoDeNoMoverse;
    [SerializeField] private float tiempoInvulnerable;

    

    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
       // bola2.position=transform.position; 

        movimientoX=Input.GetAxisRaw("Horizontal");
        movimientoY=Input.GetAxisRaw("Vertical");
        rodar=Input.GetAxisRaw("Jump");
        direccion = new Vector2(movimientoX,movimientoY).normalized;
       
        if (movimientoX!=0||movimientoY!=0)
        {
            animator.SetBool("IsWalking", true);
            ultimaDireccion=direccion;
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }

        if ((movimientoX>0) && (mirandoDerecha==false))
        {
            Girar();
        }
        else if (movimientoX<0 && mirandoDerecha)            
        {
            Girar();
        }
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
                rb2D.MovePosition(rb2D.position + ultimaDireccion * velocidadRodar * Time.fixedDeltaTime);   
                StartCoroutine(PerderControl(tiempoDeNoMoverse));
                StartCoroutine(DesactivarColision(tiempoInvulnerable));
            }   
        }     
    }

    private void Girar()
    {        
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y + 180, 0);
        mirandoDerecha=!mirandoDerecha;
    }

    public IEnumerator DesactivarColision(float TiempoInmunidad)
    {
        Physics2D.IgnoreLayerCollision(6,7,true);
        yield return new WaitForSeconds(TiempoInmunidad);
        Physics2D.IgnoreLayerCollision(6,7,false);
    }

    public IEnumerator PerderControl(float TiempoPerdidaControl)
    {
        sePuedeMover = false;
        yield return new WaitForSeconds(TiempoPerdidaControl);
        sePuedeMover = true;
    }
      
}
