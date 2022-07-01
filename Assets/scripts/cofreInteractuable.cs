using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cofreInteractuable : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator=GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if(Input.GetKey(KeyCode.E))
        {           
              //  animator.SetBool("CofreMedioAbierto", false);
                Debug.Log("no");
        }
    }   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {         
            animator.SetBool("CofreMedioAbierto", true);
            Debug.Log("Abrir cofre?");      
        }            
    }

    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            animator.SetBool("CofreMedioAbierto", false);
        }
    }
    

}
