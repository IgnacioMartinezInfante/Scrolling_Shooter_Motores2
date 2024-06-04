using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 20f; // Velocidad de la bala
    public float lifeTime = 5f; // Tiempo de vida de la bala antes de ser destruida

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
}
