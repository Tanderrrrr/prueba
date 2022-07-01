using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacionDisparo : MonoBehaviour
{
    SpriteRenderer sprite;
    [SerializeField] private Transform target;
    [SerializeField] private Transform puntaDelArma;
    //[SerializeField] private Transform controladorDisparo;
    private Vector3 mousePosition;
    private bool apuntandoDerecha;
    void Start()
	{
	       sprite = GetComponent<SpriteRenderer>();
		
  	}
    void Update()
    {
         mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         mousePosition.z = 0;
         Vector3 lookAtDirection = mousePosition -target.position;
         target.right= lookAtDirection;
	    //Debug.Log(transform.eulerAngles.z);
         if ( (transform.eulerAngles.z > 90 && transform.eulerAngles.z < 270)   &&  apuntandoDerecha)
         {
             GirarMira();
         }
         else if( ( (transform.eulerAngles.z < 90 && transform.eulerAngles.z > 0) || (transform.eulerAngles.z > 270/*-90*/ && transform.eulerAngles.z < 360) )  &&  apuntandoDerecha==false)
         {
            GirarMira();
         } 

    }

    private void GirarMira()
    {
        apuntandoDerecha= !apuntandoDerecha;
        sprite.flipY = !apuntandoDerecha;
       
        
    }
    
}
