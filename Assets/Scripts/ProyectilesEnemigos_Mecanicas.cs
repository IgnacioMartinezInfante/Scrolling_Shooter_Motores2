using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilesEnemigos_Mecanicas : MonoBehaviour, IDa�oJugador
{
    public float speed = 20f; // Velocidad de la bala
    public float lifeTime = 5f; // Tiempo de vida de la bala antes de ser destruida
    public float da�o = 10f; // Da�o que este enemigo inflige al jugador

    void Start()
    {
        // Destruye la bala despu�s de un tiempo definido
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Mueve la bala hacia adelante en l�nea recta
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public float ObtenerDa�o()
    {
        return da�o;
    }
}
