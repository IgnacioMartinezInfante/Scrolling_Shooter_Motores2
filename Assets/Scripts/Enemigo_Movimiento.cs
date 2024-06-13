using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo_Movimiento : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento del enemigo en el eje X
    public float puntoDeFrenoX = 10f; // Punto donde el enemigo debe frenar en el eje X
    private bool frenando = false;

    void Update()
    {
        // Mueve al enemigo hacia adelante en el eje X si no est� frenando
        if (!frenando)
        {
            // Calcula el movimiento en el eje X
            float movimientoZ = velocidad * Time.deltaTime;

            // Mueve el enemigo en el eje X
            transform.Translate(0, 0, movimientoZ);

            // Frena al llegar al punto de freno en el eje X
            if (transform.position.x <= puntoDeFrenoX)
            {
                frenando = true;
            }
        }
    }
}
