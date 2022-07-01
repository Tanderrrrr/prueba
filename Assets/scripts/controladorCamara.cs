using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controladorCamara : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float SSpeed;
    [SerializeField] float zOffset;
    private Transform _t;
    private void Awake()
    {
        _t = GetComponent<Transform>();
    }
    void Update()
    {
        CalcularPosicionCamara();
                
    }
    private void CalcularPosicionCamara()
    {
        Vector2 playerPos = player.position;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 dir = mousePos - playerPos;
        Vector3 newPos = playerPos + dir / 4;
        Vector3 Sposition = Vector2.Lerp(_t.position, newPos, SSpeed * Time.deltaTime);
        _t.position = new Vector3(Sposition.x, Sposition.y, zOffset);
    }
}
