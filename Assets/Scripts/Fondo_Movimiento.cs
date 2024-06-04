using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fondo_Movimiento : MonoBehaviour
{
    public float speed = 5f; // Velocidad del movimiento del fondo
    public Vector3 startPosition; // Posici�n inicial del segmento
    public Vector3 endPosition; // Posici�n final del segmento

    void Update()
    {
        // Mueve el segmento hacia la posici�n final
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Si el segmento llega a la posici�n final, lo regresa a la posici�n inicial
        if (transform.position.x <= endPosition.x)
        {
            transform.position = startPosition;
        }
    }
}
