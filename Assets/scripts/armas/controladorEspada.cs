using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorEspada : MonoBehaviour
{
    private Animator Animator;
    private Transform _t;
    [SerializeField] private Transform controladorGolpe;
    [SerializeField] private float radioGolpe;

    void Start()
    {
        _t = GetComponent<Transform>();
        Animator = GetComponent<Animator>();
    }

    private void Golpe()
    {

    }
}
