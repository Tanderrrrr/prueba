using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorOjos : MonoBehaviour
{
    [SerializeField] private Transform apuntado;
    private Animator animator;
    private Vector3 mousePosition;
    [SerializeField] private Transform target;
    [SerializeField] private Transform jugador;
    [SerializeField] private Vector3 ojosLugar;
    private Vector3 posicionOjos;
    [SerializeField] private float distanciaMiradaX;
    [SerializeField] private float distanciaMiradaY;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
         mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         mousePosition.z = 0;
         Vector3 lookAtDirection = mousePosition -target.position;             

        if (lookAtDirection.x>=distanciaMiradaX)
        {
            posicionOjos.x= jugador.position.x + 0.08f;
            
        }
        else if(lookAtDirection.x<=-distanciaMiradaX)
        {
            posicionOjos.x= jugador.position.x - 0.08f;
        }
        else
        {
            posicionOjos.x= jugador.position.x;
        }

        if (lookAtDirection.y>=distanciaMiradaY)
        {
            posicionOjos.y= jugador.position.y + 0.08f;

        }
        else if(lookAtDirection.y<=-distanciaMiradaY)
        {
            posicionOjos.y= jugador.position.y - 0.08f;
        }
        else
        {
             posicionOjos.y= jugador.position.y;

        }
        
        transform.position = posicionOjos;      

    }
}
