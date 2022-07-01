using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agarrarArma : MonoBehaviour
{
    [SerializeField] private GameObject armaActivador;

    void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.tag == "Player")
            {
                armaActivador.SetActive(true);
                Destroy(gameObject);
            }
        }
}
