using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piedras_Enemigas_Movimiento : MonoBehaviour
{
    public float speed = 5f; // Velocidad del movimiento del fondo
    public Vector3 endPosition; // Posición final del segmento.

    void Update()
    {
        // Mueve el segmento hacia la posición final
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Si el segmento llega a la posición final, lo destruye
        if (transform.position.x <= endPosition.x)
        {
            Destroy();
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
