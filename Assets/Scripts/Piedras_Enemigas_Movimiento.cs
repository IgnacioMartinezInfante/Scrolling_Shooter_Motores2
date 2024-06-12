using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piedras_Enemigas_Movimiento : MonoBehaviour, IDa�o, IDa�oJugador
{
    public float speed = 5f; // Velocidad del movimiento del fondo
    public Vector3 endPosition; // Posici�n final del segmento.
    public float vida = 5;
    public float da�o = 10f; // Da�o que este enemigo inflige al jugador

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

    public float ObtenerDa�o()
    {
        return da�o;
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
