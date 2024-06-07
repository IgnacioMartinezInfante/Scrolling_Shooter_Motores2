using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piedras_Enemigas_Movimiento : MonoBehaviour, IDa�o
{
    public float speed = 5f; // Velocidad del movimiento del fondo
    public Vector3 endPosition; // Posici�n final del segmento.
    public float vida = 5;

    void Update()
    {
        // Mueve el segmento hacia la posici�n final
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        // Si el segmento llega a la posici�n final, lo destruye
        if (transform.position.x <= endPosition.x)
        {
            Destroy();
        }
    }
    public void RecibirDa�o(float damage)
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
