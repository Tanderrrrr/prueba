using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparosJugador : MonoBehaviour
{
    [SerializeField] private Transform puntaDelArma;
    [SerializeField] private GameObject Bala;
    [SerializeField] private float dispararCooldown;
    private Vector3 mousePosition;
    private float dispararPermiso;
    private bool disparar;
    private Rigidbody2D rb;
    [SerializeField] private float velocidad;

    private void Update() 
    {
        disparar=Input.GetButton("Fire1");

         if (disparar== true && Time.time > dispararPermiso)
        {
            Disparar();
        }   
    }
    void Disparar()
    {
        GameObject bala = Instantiate(Bala, puntaDelArma.position, puntaDelArma.rotation);
        dispararPermiso = Time.time + dispararCooldown; 
        Rigidbody2D rb = bala.GetComponent<Rigidbody2D>();
        rb.AddForce(puntaDelArma.right * velocidad , ForceMode2D.Impulse);
    }
}
