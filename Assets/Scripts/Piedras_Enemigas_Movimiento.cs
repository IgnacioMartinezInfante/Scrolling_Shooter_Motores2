using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piedras_Enemigas_Movimiento : MonoBehaviour, IDaño
{
    public float speed = 5f; // Velocidad del movimiento del fondo
    public Vector3 endPosition; // Posición final del segmento.
    public float vida = 5;

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
    public void RecibirDaño(float damage)
    {
        vida -= damage;
        if (vida <= 0)
        {
            Destroy();
        }
    }
    private void Destroy()
    {
        Destroy(gameObject);
    }
}
