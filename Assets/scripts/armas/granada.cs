using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class granada : MonoBehaviour
{
    [SerializeField] private float tiempoGranada;
    [SerializeField] private GameObject explosionEfecto;
    private  Quaternion ultimaRotacion;
    private Animator animator;
    private Transform _t;
    private float tiempoGranadaExplosion =1f;
    private float timepoGranadaContador;
    private void Start()
    {
    	animator= GetComponent<Animator>();
        _t = GetComponent<Transform>();
        timepoGranadaContador=Time.time + tiempoGranada; 
    }
    private void FixedUpdate() 
    {
        if (timepoGranadaContador < Time.time)
        {
            timepoGranadaContador=Time.time + tiempoGranada;
            Explosion();
        }
    }     
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemigo"))
        {         
            Explosion();
        }
    }
    private void Explosion()
    {
        ultimaRotacion = Quaternion.Euler(0,0, _t.eulerAngles.z);
        GameObject explosion = Instantiate(explosionEfecto, _t.position, ultimaRotacion);
        Destroy(explosion, tiempoGranadaExplosion);
        Destroy(gameObject);

    }
}
