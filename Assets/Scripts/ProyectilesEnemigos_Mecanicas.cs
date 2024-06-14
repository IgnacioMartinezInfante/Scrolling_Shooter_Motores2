using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilesEnemigos_Mecanicas : MonoBehaviour, IDañoJugador
{
    public float speed = 20f; // Velocidad de la bala
    public float lifeTime = 5f; // Tiempo de vida de la bala antes de ser destruida
    public float daño = 10f; // Daño que este enemigo inflige al jugador

    void Start()
    {
        // Destruye la bala después de un tiempo definido
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Mueve la bala hacia adelante en línea recta
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    public float ObtenerDaño()
    {
        return daño;
    }
}
