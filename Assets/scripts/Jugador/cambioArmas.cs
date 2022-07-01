using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cambioArmas : MonoBehaviour
{
    /*[SerializeField] private GameObject rifle;
    [SerializeField] private GameObject arma;*/
    [SerializeField] private GameObject activadorArma;
    [SerializeField] private float coolDown;
    private float cambiarPermiso;
    public GameObject[] armas;
    private int armaActiva=0; //rifle 1, lanzagranadas 2, ? 3
    private float scrollMouse;
    private int cantDeArmas;
    
    void Update()
    {
        cantDeArmas=armas.Length;
        scrollMouse=Input.GetAxisRaw("Mouse ScrollWheel");     

        //Seleccion de arma
        if(Time.time > cambiarPermiso && scrollMouse!=0)
        {
            if (scrollMouse>0)
            {
                armaActiva++;
            }
            else if(scrollMouse<0)
            {
                armaActiva-=1;
            }

            if (armaActiva==cantDeArmas)
            {
                armaActiva=0;
            }
            else if(armaActiva<=-1)
            {
                armaActiva=cantDeArmas-1;
            }

        }

        //Activar arma
        switch (armaActiva)
        {
            case 0:
                for (int i = 0; i < cantDeArmas; i++)
                {
                    if (i!=0)
                    {
                        armas[i].SetActive(false);
                    }
                    armas[0].SetActive(true);
                }
            break;

            case 1:   
                for (int i = 0; i < cantDeArmas; i++)
                {
                    if (i!=1)
                    {
                        armas[i].SetActive(false);
                    }
                }                          
                armas[1].SetActive(true);
            break;

            case 2:
                for (int i = 0; i < cantDeArmas; i++)
                {
                    if (i!=2)
                    {
                        armas[i].SetActive(false);
                    }
                }                          
            armas[2].SetActive(true);
            break;         
        }
    }
}
