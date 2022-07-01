using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorVidas : MonoBehaviour
{
    private movimientoJugador movimientoJugador;
    [SerializeField] private int vidaJugador;
    private Animator animator;
    [SerializeField] private GameObject bufanda;
    [SerializeField] private float tiempoPerdidaControl;
    [SerializeField] private float tiempoInmunidad;

    void Start()
    {
        animator = GetComponent<Animator>();
        movimientoJugador= GetComponent<movimientoJugador>();

    }
    void Update()
    {
       /* if (vidaJugador<=0)
        {
            Debug.Log("ESTAS MUERTO!!!");
            PerderControl();
            Destroy(bufanda,1.5f);
            Destroy(gameObject,1.5f);
            animator.SetBool("Dead", true);
        }*/        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("dañoEnemigo"))
        {
            TomarDaño();
        }
    }
    public void TomarDaño()
    {
        vidaJugador--;
        animator.SetBool("Idle",false);
        animator.SetTrigger("Dañado");
        Debug.Log("Vida="+vidaJugador);
        StartCoroutine(PerderControl(tiempoPerdidaControl));
        StartCoroutine(DesactivarColision(tiempoInmunidad));
    }
    public IEnumerator DesactivarColision(float TiempoInmunidad)
    {
        Physics2D.IgnoreLayerCollision(6,7,true);
        yield return new WaitForSeconds(TiempoInmunidad);
        Physics2D.IgnoreLayerCollision(6,7,false);
    }

    public IEnumerator PerderControl(float TiempoPerdidaControl)
    {
        movimientoJugador.sePuedeMover = false;
        yield return new WaitForSeconds(TiempoPerdidaControl);
        movimientoJugador.sePuedeMover = true;
    }

}
